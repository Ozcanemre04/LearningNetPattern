using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repository.Interface
{
    public interface IUnitOfWork
    {
        IDriverRepository Drivers { get; }
        IAchievementRepository Achievements  { get; }

        Task<bool> completeAsync();
    }
}