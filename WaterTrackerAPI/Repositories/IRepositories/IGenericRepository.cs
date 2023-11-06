using System.Linq.Expressions;

namespace WaterTrackerAPI.Repositories.IRepositories
{
    // An interface which declares the methods for the generic repository class and allows for dependency injection
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, Expression<Func<T, bool>>? orderBy = null, string ? includeProperties = null);
        Task<T> Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
        void Add(T entity);
        Task<T> Remove(T entity);
        
    }
}
