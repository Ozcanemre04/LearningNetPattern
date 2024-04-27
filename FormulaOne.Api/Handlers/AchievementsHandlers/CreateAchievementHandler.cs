using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FormulaOne.Api.commands.AchievementCommands;
using FormulaOne.DataService.Repository.Interface;
using FormulaOne.Entities;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers.AchievementsHandlers
{
    public class CreateAchievementHandler : BaseHandler, IRequestHandler<CreateAchievementCommand, AchievementResponse>
    {
        public CreateAchievementHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<AchievementResponse> Handle(CreateAchievementCommand request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.Drivers.GetById(request.AddAchievementRequest.DriverId) ?? null;
            
            var achievement = _mapper.Map<Achievement>(request.AddAchievementRequest);
            achievement.DriverId = driver.Id;
            await _unitOfWork.Achievements.Add(achievement);
            await _unitOfWork.completeAsync();
            return _mapper.Map<AchievementResponse>(achievement);
        }
    }
}