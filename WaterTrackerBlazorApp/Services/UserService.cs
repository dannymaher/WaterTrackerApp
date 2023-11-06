using System.Net.Http;
using System.Net.Http.Json;
using WaterTrackerApp.Models.Dtos;
using WaterTrackerBlazorApp.Services.Contracts;

namespace WaterTrackerBlazorApp.Services
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
                var response =  await this._httpClient.GetAsync($"api/User/{id}" );
                if (response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(UserDto);
                    }
                    return await response.Content.ReadFromJsonAsync<UserDto>();
                }
                else { 
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception )
            {
                throw;
            }


        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/User");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<UserDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<UserDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception ) { throw; }

        }
        public async Task<UserDto> AddUser(UserDto user)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/User", user);
                return await response.Content.ReadFromJsonAsync<UserDto>();
            }
            catch(Exception ) { throw; }
            
        }

        public async Task<UserDto> UpdateUser(UserDto user, int id)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/User/{id}", user);
                return await response.Content.ReadFromJsonAsync<UserDto>();
            }
            catch (Exception) { throw; }
        }

        public async Task<UserDto> DeleteUser( int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/User/{id}");
                return await response.Content.ReadFromJsonAsync<UserDto>();
            }
            catch (Exception) { throw; }
        }
    }
}
