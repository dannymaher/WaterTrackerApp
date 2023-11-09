using Microsoft.AspNetCore.Components;
using WaterTrackerApp.Models.Dtos;
using WaterTrackerBlazorApp.Services.Contracts;

namespace WaterTrackerBlazorApp.Pages
{
    public class WaterRecordUpsertBase :ComponentBase
    {
        public WaterIntakeDto Record { get; set; } = new WaterIntakeDto();
        [Parameter]
        public int Id { get; set; }
        [Parameter]
        public int UserId { get; set; }

        [Inject]
        public IUserService UserService { get; set; }
        [Inject]
        public IWaterIntakeService WaterIntakeService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                if (Id != 0)
                {
                    Record = await WaterIntakeService.GetRecord(Id);

                }
                else
                {
                    UserDto user = await UserService.GetUser(UserId);

                    Record.UserID = UserId;
                    Record.UserName = user.FirstName + " " + user.LastName;
                    Record.IntakeDate = DateTime.Now;
                }
            }catch (Exception ex) { }
            
        }
        protected async Task HandleSubmit()
        {
            WaterIntakeDto result = null;
            if (Record.Id != 0)
            {
                result = await WaterIntakeService.UpdateRecord(Record, Id);
            }
            else
            {
                result = await WaterIntakeService.AddRecord(Record);
            }
            //var result = await UserService.AddUser(User);
            NavigationManager.NavigateTo($"/UserDetails/{Record.UserID}");
        }
    }
}
