

using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Queries.AchievementsQueries
{
    public class GetAchievementQuery : IRequest<AchievementResponse>
    {
        public Guid AchievementId { get; }
        public GetAchievementQuery(Guid achievementId)
        {
            AchievementId = achievementId;
        }

    }
}