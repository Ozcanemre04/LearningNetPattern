using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Api.commands.AchievementCommands
{
    public class UpdateAchievementCommand : IRequest<bool>
    {
         public Guid AchievementId { get; }
         public UpdateAchievementRequest UpdateAchievementRequest;
        
        public UpdateAchievementCommand(Guid achievementId, UpdateAchievementRequest updateAchievementRequest)
        {
            AchievementId = achievementId;
            UpdateAchievementRequest = updateAchievementRequest;
        }
    }
}