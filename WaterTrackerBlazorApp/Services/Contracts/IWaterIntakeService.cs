using WaterTrackerApp.Models.Dtos;

namespace WaterTrackerBlazorApp.Services.Contracts
{
    public interface IWaterIntakeService
    {
        Task<IEnumerable<WaterIntakeDto>> GetRecordsByUserId(int Id);
        Task<WaterIntakeDto> GetRecord(int id);
        Task<WaterIntakeDto> AddRecord(WaterIntakeDto record);
        Task<WaterIntakeDto> UpdateRecord(WaterIntakeDto record, int Id);
        Task<WaterIntakeDto> DeleteRecord(int id);
    }
}
