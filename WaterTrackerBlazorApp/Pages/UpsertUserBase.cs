using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;
using WaterTrackerApp.Models.Dtos;
using WaterTrackerBlazorApp.Services;
using WaterTrackerBlazorApp.Services.Contracts;

namespace WaterTrackerBlazorApp.Pages
{
    public class UpsertUserBase :ComponentBase
    {
        public UserDto User { get; set; } = new UserDto();
        [Parameter]
        public int Id {  get; set; }

        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if(Id != 0)
            {
                User = await UserService.GetUser(Id);

            }
        }
        protected async Task HandleSubmit()
        {
            UserDto result = null;
            if(User.Id != 0)
            {
                result = await UserService.UpdateUser(User,Id);
                NavigationManager.NavigateTo($"/UserDetails/{User.Id}");
            }
            else
            {
                 result = await UserService.AddUser(User);
                NavigationManager.NavigateTo("/");
            }
            
            //NavigationManager.NavigateTo("/");
        }
    }
}
