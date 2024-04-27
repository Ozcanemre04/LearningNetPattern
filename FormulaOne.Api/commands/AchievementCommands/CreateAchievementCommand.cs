using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.commands.AchievementCommands
{
    public class CreateAchievementCommand : IRequest<AchievementResponse>
    {
        public AddAchievementRequest AddAchievementRequest { get; }
        
        public CreateAchievementCommand(AddAchievementRequest addDriverRequest)
        {
            AddAchievementRequest = addDriverRequest;
            
        }
    }
}