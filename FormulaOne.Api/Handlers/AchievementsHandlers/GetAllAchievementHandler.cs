using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FormulaOne.Api.Queries.AchievementsQueries;
using FormulaOne.DataService.Repository.Interface;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers.AchievementsHandlers
{
    public class GetAllAchievementHandler : BaseHandler, IRequestHandler<GetAllAchievementsQuery, IEnumerable<AchievementResponse>>
    {
        public GetAllAchievementHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<AchievementResponse>> Handle(GetAllAchievementsQuery request, CancellationToken cancellationToken)
        {
            var achievements = await _unitOfWork.Achievements.GetAll();
            return _mapper.Map<IEnumerable<AchievementResponse>>(achievements);
        }
    }
}