using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FormulaOne.Api.commands.AchievementCommands;
using FormulaOne.DataService.Repository.Interface;
using MediatR;

namespace FormulaOne.Api.Handlers.AchievementsHandlers
{
    public class UpdateAchievementHandler : BaseHandler, IRequestHandler<UpdateAchievementCommand, bool>
    {
        public UpdateAchievementHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> Handle(UpdateAchievementCommand request, CancellationToken cancellationToken)
        {
            var achievement = await _unitOfWork.Achievements.GetById(request.AchievementId);
            if (achievement == null)
            {
                return false;
            }
            _mapper.Map(request.UpdateAchievementRequest, achievement);
            await _unitOfWork.Achievements.Update(achievement);
            await _unitOfWork.completeAsync();

            return true;
        }
    }
}