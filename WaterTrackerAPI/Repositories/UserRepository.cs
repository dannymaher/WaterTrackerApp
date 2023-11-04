using WaterTrackerAPI.Data;
using WaterTrackerAPI.Entities;
using WaterTrackerAPI.Repositories.IRepositories;

namespace WaterTrackerAPI.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db):base(db) 
        {
            _db = db;
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
