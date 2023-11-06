using WaterTrackerAPI.Entities;

namespace WaterTrackerAPI.Repositories.IRepositories
{
    // An interface which declares the methods for the water intake repository class and allows for dependency injection
    public interface IWaterIntakeRepository : IGenericRepository<WaterIntake>
    {
        Task<WaterIntake> Update(WaterIntake entity, int id);
    }
}
