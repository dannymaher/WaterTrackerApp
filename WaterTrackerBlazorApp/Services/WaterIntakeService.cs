using System.Net.Http.Json;
using WaterTrackerApp.Models.Dtos;
using WaterTrackerBlazorApp.Services.Contracts;

namespace WaterTrackerBlazorApp.Services
{
    public class WaterIntakeService : IWaterIntakeService
    {
        private readonly HttpClient _httpClient;

        public WaterIntakeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WaterIntakeDto> AddRecord(WaterIntakeDto record)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/WaterIntake", record);
                return await response.Content.ReadFromJsonAsync<WaterIntakeDto>();
            }
            catch (Exception) { throw; }
        }

        public async Task<WaterIntakeDto> DeleteRecord(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/WaterIntake/{id}");
                return await response.Content.ReadFromJsonAsync<WaterIntakeDto>();
            }
            catch (Exception) { throw; }
        }

        public async Task<WaterIntakeDto> GetRecord(int id)
        {
            try
            {
                var response = await this._httpClient.GetAsync($"api/WaterIntake/getById/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(WaterIntakeDto);
                    }
                    return await response.Content.ReadFromJsonAsync<WaterIntakeDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
            


        public async Task<IEnumerable<WaterIntakeDto>> GetRecordsByUserId(int Id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/WaterIntake/{Id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<WaterIntakeDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<WaterIntakeDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception) { throw; }
        }

        public async Task<WaterIntakeDto> UpdateRecord(WaterIntakeDto record, int Id)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/WaterIntake/{Id}", record);
                return await response.Content.ReadFromJsonAsync<WaterIntakeDto>();
            }
            catch (Exception) { throw; }
        }
    }
}
