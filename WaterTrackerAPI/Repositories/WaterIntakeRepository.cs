using WaterTrackerAPI.Data;
using WaterTrackerAPI.Entities;
using WaterTrackerAPI.Repositories.IRepositories;

namespace WaterTrackerAPI.Repositories
{
    public class WaterIntakeRepository : GenericRepository<WaterIntake>, IWaterIntakeRepository
    {
        private ApplicationDbContext _db;

        public WaterIntakeRepository(ApplicationDbContext db):base(db) 
        {
            _db = db;
        }

        public void update(WaterIntake entity)
        {
            throw new NotImplementedException();
        }
    }
}
