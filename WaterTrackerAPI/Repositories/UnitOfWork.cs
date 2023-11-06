using WaterTrackerAPI.Data;
using WaterTrackerAPI.Repositories.IRepositories;

namespace WaterTrackerAPI.Repositories
{
    //Class which wraps all repositories and allows them to share the same instance of the db context and use one transaction for all changes
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IUserRepository User { get; private set; }
        public IWaterIntakeRepository WaterIntake { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            User = new UserRepository(_db);
            WaterIntake = new WaterIntakeRepository(_db);
        }

        // Saves all db changes
        public async Task Save()
        {
            await _db.SaveChangesAsync();
            
        }
    }
}
