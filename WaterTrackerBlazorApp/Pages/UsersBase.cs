using Microsoft.AspNetCore.Components;
using WaterTrackerApp.Models.Dtos;

namespace WaterTrackerBlazorApp.Pages
{
    public class UsersBase :ComponentBase
    {
        [Inject]
        public Services.Contracts.IUserService UserService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }
        public IEnumerable<UserDto> users { get; set; }

        protected override async Task OnInitializedAsync()
        {
            users = await UserService.GetUsers();
        }
        
        public void ViewUserDetails(int id)
        {
            NavigationManager.NavigateTo($"/UserDetails/{id}");
        }
        public void CreateUser()
        {
            NavigationManager.NavigateTo($"/UpsertUser");
        }
        
       
    }
}
