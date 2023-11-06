using System.Net.Http.Json;
using WaterTrackerApp.Models.Dtos;
using WaterTrackerApp.Services.IServices;

namespace WaterTrackerApp.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDto> GetUser(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<UserDto>("api/user/"+id);
            }
            catch (Exception ex) {
                throw;
            }
            
            
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<UserDto>>("api/user");
            }
            catch (Exception ex) { throw; }
            
        }
    }
}
