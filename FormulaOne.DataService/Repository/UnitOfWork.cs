using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repository.Interface;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repository
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private AppDbContext _appDbContext;
        public IDriverRepository Drivers { get; }

        public IAchievementRepository Achievements { get; }
        public UnitOfWork(AppDbContext appDbContext, ILoggerFactory loggerFactory)
        {
            _appDbContext = appDbContext;
            var logger = loggerFactory.CreateLogger("logs");
            Drivers = new DriverRepository(_appDbContext,logger);
            Achievements = new AchievementsRepository(_appDbContext,logger);
        }

        public async Task<bool> completeAsync()
        {
            var result = await _appDbContext.SaveChangesAsync();
            return result > 0; 
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}