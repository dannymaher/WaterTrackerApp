using WaterTrackerAPI.Entities;

namespace WaterTrackerAPI.Repositories.IRepositories
{
    // An interface which declares the methods for the user repository class and allows for dependency injection
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User>Update(User entity, int id);
    }
}
