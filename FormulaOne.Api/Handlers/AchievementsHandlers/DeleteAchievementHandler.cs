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
    public class DeleteAchievementHandler : BaseHandler, IRequestHandler<DeleteAchievementCommand, bool>
    {
        public DeleteAchievementHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> Handle(DeleteAchievementCommand request, CancellationToken cancellationToken)
        {
            var achievement = await _unitOfWork.Achievements.GetById(request.AchievementId);
            if (achievement == null)
            {
                return false;
            }
            await _unitOfWork.Achievements.Delete(achievement);
            await _unitOfWork.completeAsync();
            return true;
        }
    }
}