using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Queries.AchievementsQueries
{
    public class GetAllAchievementsQuery : IRequest<IEnumerable<AchievementResponse>>
    {
        
    }
}