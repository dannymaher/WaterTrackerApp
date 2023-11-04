using WaterTrackerAPI.Entities;

namespace WaterTrackerAPI.Repositories.IRepositories
{
    public interface IWaterIntakeRepository : IGenericRepository<WaterIntake>
    {
        void update(WaterIntake entity);
    }
}
