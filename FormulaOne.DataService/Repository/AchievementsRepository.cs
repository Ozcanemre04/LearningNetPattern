
using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repository.Interface;
using FormulaOne.Entities;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repository
{
    public class AchievementsRepository : GenericRepository<Achievement>, IAchievementRepository
    {
        public AchievementsRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}