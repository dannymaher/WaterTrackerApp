using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WaterTrackerAPI.Data;
using WaterTrackerAPI.Repositories.IRepositories;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Diagnostics;

namespace WaterTrackerAPI.Repositories
{
    //A class which implements the generic repository interface and is responsible for all CRUD operations besides updates on all entities in the db 
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> DbSet; //Represents the table in the db

        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
            this.DbSet = _db.Set<T>();
            _db.WaterIntake.Include(u => u.User).Include(u => u.UserID); // Include the field that the foreign key maps to in db transactions for water intake
        }

        //adds a record to the specified db table
        public async void Add(T entity)
        {
            await DbSet.AddAsync(entity); 
        }

        //Gets a record from the specified db table based upon a linq expression
        public async Task<T> Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true) 
        {
            IQueryable<T> query = DbSet;
            if (tracked)
            {
                DbSet.AsTracking();
            }
            else
            {
                DbSet.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var property in includeProperties
                    .Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return query.FirstOrDefault();
        }

        //Gets a list of records from the specified db table based upon a linq expression and an optional parameter to order them
        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, Expression<Func<T, bool>>?  orderBy = null, string? includeProperties = null)
        {

            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var property in includeProperties
                    .Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            if (orderBy != null)
            {
               query = query.OrderBy(orderBy);
            }
            return  query.ToList();
        }

        //Removes a record from the specified db table
        public async Task<T >Remove(T entity)
        {
            DbSet.Remove(entity);
            
            return entity;
        }
    }
}
