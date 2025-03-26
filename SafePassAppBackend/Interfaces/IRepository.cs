using System.Linq.Expressions;

namespace SafePassAppBackend.Interfaces
{
    public interface IRepository<T, Tkey> where T : class
    {

        public Task<T?> GetById(Tkey id);
        public Task<ICollection<T>> GetAll();
        public Task<ICollection<T>> Find(Expression<Func<T, bool>> expression); // придумать как реализовать Find
        public Task<T> Add(T item);
        public T Update(T item);
        public void Delete(T item);
        public Task CommitChangesAsync();

    }
}
