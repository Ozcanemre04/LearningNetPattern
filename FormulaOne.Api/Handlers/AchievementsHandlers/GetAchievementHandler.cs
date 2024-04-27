using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FormulaOne.Api.Queries.AchievementsQueries;
using FormulaOne.Api.Queries.DriversQueries;
using FormulaOne.DataService.Repository.Interface;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers.AchievementsHandlers
{
    public class GetAchievementHandler : BaseHandler, IRequestHandler<GetAchievementQuery, AchievementResponse>
    {
        public GetAchievementHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<AchievementResponse> Handle(GetAchievementQuery request, CancellationToken cancellationToken)
        {
            var achievement = await _unitOfWork.Achievements.GetById(request.AchievementId);
            if (achievement == null)
            {
                return null;
            }
            return _mapper.Map<AchievementResponse>(achievement);
        }
    }
}