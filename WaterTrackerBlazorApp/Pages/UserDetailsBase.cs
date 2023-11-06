using Microsoft.AspNetCore.Components;
using WaterTrackerApp.Models.Dtos;
using WaterTrackerBlazorApp.Services;
using WaterTrackerBlazorApp.Services.Contracts;

namespace WaterTrackerBlazorApp.Pages
{
    public class UserDetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        public UserDto User { get; set; }

        [Inject]
        public IUserService UserService { get; set; }

        public string ErrorMessage { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                User = await UserService.GetUser(Id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            
        }
        public void EditUser()
        {
            NavigationManager.NavigateTo($"/UpsertUser/{Id}");
        }
        public async void DeleteUser(int id)
        {
            await UserService.DeleteUser(id);
            NavigationManager.NavigateTo("/");
        }
        public void AddRecord(int UserId)
        {
            NavigationManager.NavigateTo($"/WaterRecordUpsert/{0}/{UserId}");
        }
    }
}
