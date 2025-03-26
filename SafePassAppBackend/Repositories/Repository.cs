using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SafePassAppBackend.Interfaces;
using SafePassAppBackend.SPDbContext;

namespace SafePassAppBackend.Repositories
{
    public class Repository<T, Tkey> : IRepository<T, Tkey> where T : class
    {
        private readonly SafePassDbContext _dbContext;
        public Repository(SafePassDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T item)
        {
            var res = await _dbContext.Set<T>().AddAsync(item);
            return res.Entity;
        }

        public async Task CommitChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(T item)
        {
            _dbContext.Set<T>().Remove(item);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Where(expression).AsQueryable();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Tkey id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public T Update(T item)
        {
            return _dbContext.Set<T>().Update(item).Entity;
        }
    }
}
