using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using WaterTrackerApp.Models.Dtos;
using WaterTrackerBlazorApp.Services.Contracts;

namespace WaterTrackerBlazorApp.Pages
{
    public class UserWaterIntakeTableBase :ComponentBase
    {
        [Inject]
        public IWaterIntakeService WaterIntakeService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }
        public IEnumerable<WaterIntakeDto> Records { get; set; } = Enumerable.Empty<WaterIntakeDto>();

        [Parameter]
        public int UserId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await getUserRecords();
            

        }
        public void EditRecordDetails(int id)
        {
            NavigationManager.NavigateTo($"/WaterRecordUpsert/{id}");
        }
        public async void DeleteRecord(int id)
        {
            
            await WaterIntakeService.DeleteRecord(id);
            await getUserRecords();
            StateHasChanged();
        }
        public async Task getUserRecords()
        {
            var list = await WaterIntakeService.GetRecordsByUserId(UserId);
            if (list != null)
            {
                Records = list;
            }
            else
            {
                Records = new List<WaterIntakeDto>();
            }
        }
    }
}
