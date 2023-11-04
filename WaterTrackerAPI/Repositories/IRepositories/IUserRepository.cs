using WaterTrackerAPI.Entities;

namespace WaterTrackerAPI.Repositories.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        void Update(User entity);
    }
}
