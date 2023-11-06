
using Microsoft.AspNetCore.Components;
using WaterTrackerApp.Models.Dtos;
using WaterTrackerApp.Services.IServices;

namespace WaterTrackerApp.Pages
{
    public class UsersBase: ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }
        public IEnumerable<UserDto> users { get; set; }

        protected override async Task OnInitializedAsync()
        {
            users = await UserService.GetUsers();
        }
        

       

        
    }
}
