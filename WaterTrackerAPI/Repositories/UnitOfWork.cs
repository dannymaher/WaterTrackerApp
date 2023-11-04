using WaterTrackerAPI.Data;
using WaterTrackerAPI.Repositories.IRepositories;

namespace WaterTrackerAPI.Repositories
{
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

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
