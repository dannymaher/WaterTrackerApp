using WaterTrackerApp.Models.Dtos;

namespace WaterTrackerBlazorApp.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> GetUser(int id);
        Task<UserDto> AddUser(UserDto user);
        Task<UserDto> UpdateUser(UserDto user,int Id);
        Task<UserDto> DeleteUser(int id);
    }
}
