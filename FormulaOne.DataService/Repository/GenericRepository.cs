
using FormulaOne.DataService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    public AppDbContext _context { get; set; }
    public readonly ILogger _logger;
    internal DbSet<T> _dbSet;
    private AppDbContext context;

    public GenericRepository(AppDbContext context, ILogger logger)
    {
        _logger = logger;
        _context = context;
        _dbSet = _context.Set<T>();

    }


    public virtual async Task<bool> Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        return true;
    }

    public virtual async Task<bool> Delete(T entity)
    {
         _dbSet.Remove(entity);
        return true;
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<T?> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<bool> Update(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        return true;
    }
}

