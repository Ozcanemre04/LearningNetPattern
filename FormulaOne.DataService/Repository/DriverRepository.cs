

using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repository.Interface;
using FormulaOne.Entities;

namespace FormulaOne.DataService.Repository
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(AppDbContext context) : base(context)
        {
        }
    }
}