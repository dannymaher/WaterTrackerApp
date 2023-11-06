using System;
using WaterTrackerAPI.Data;
using WaterTrackerAPI.Entities;
using WaterTrackerAPI.Repositories.IRepositories;

namespace WaterTrackerAPI.Repositories
{
    //A class for handling operations specifically for the user entity
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //Updates a user db record
        public async Task<User> Update(User entity,int id)
        {
            var item = await _db.Users.FindAsync(id);
            
            if(item != null)
            {
                item.FirstName = entity.FirstName;
                item.LastName = entity.LastName;
                item.Email = entity.Email;
                _db.Users.Update(item);
                
                return item;
            }
            return null;

        }

    }
}
