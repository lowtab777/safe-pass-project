using System.Linq.Expressions;

namespace SafePassAppBackend.Interfaces
{
    public interface IRepository<T, Tkey> where T : class
    {

        public Task<T?> GetByIdAsync(Tkey id);
        public Task<ICollection<T>> GetAllAsync();
        public IQueryable<T> Find(Expression<Func<T, bool>> expression); // придумать как реализовать Find
        public Task<T> AddAsync(T item);
        public T Update(T item);
        public void Delete(T item);
        public Task CommitChangesAsync();

    }
}
