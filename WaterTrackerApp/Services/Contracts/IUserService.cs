using WaterTrackerApp.Models.Dtos;

namespace WaterTrackerApp.Services.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> GetUser(int id);
    }
}
