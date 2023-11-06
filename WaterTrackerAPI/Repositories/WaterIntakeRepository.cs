using WaterTrackerAPI.Data;
using WaterTrackerAPI.Entities;
using WaterTrackerAPI.Repositories.IRepositories;

namespace WaterTrackerAPI.Repositories
{
    //A class for handling operations specifically for the water intake entity
    public class WaterIntakeRepository : GenericRepository<WaterIntake>, IWaterIntakeRepository
    {
        private ApplicationDbContext _db;

        public WaterIntakeRepository(ApplicationDbContext db):base(db) 
        {
            _db = db;
        }

        //Updates a water intake db record
        public async Task<WaterIntake> Update(WaterIntake entity, int id)
        {
            var item = await _db.WaterIntake.FindAsync(id);
            
            if (item != null)
            {
                item.IntakeDate = entity.IntakeDate;
                item.ConsumedWater = entity.ConsumedWater;
                
                _db.WaterIntake.Update(item);
                
                return item;
            }
            return null;
        }
        
    }
}
