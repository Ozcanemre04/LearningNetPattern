
using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repository.Interface;
using FormulaOne.Entities;

namespace FormulaOne.DataService.Repository
{
    public class AchievementsRepository : GenericRepository<Achievement>, IAchievementRepository
    {
        public AchievementsRepository(AppDbContext context) : base(context)
        {
        }
    }
}