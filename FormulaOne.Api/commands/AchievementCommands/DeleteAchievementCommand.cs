using MediatR;

namespace FormulaOne.Api.commands.AchievementCommands
{
    public class DeleteAchievementCommand : IRequest<bool>
    {
        public Guid AchievementId { get; }
        
        public DeleteAchievementCommand(Guid achievementId)
        {
            AchievementId = achievementId;
        }
    }
}