using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WaterTrackerAPI.Data;
using WaterTrackerAPI.Repositories.IRepositories;
using System.Linq.Expressions;

namespace WaterTrackerAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> DbSet;

        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
            this.DbSet = _db.Set<T>();
            _db.WaterIntake.Include(u => u.User).Include(u => u.UserID);
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, IOrderedQueryable<T> orderBy = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
