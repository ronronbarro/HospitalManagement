using HospitalManagement.Shared.DataServices.Interfaces;
using HospitalManagement.Shared.Dto;
using Microsoft.AspNetCore.Components;

namespace HospitalManagement.Blazor.Server.Pages
{
    public partial class Login : ComponentBase
    {
        [Inject] private IUserDataService? UserDataService { get; set; }
        [Inject] private NavigationManager? NavigationManager { get; set; }
        private LoginDto LoginDto { get; set; } = new();

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        private async void OnLogin()
        {
            if (LoginDto != null)
            {
                var result = await UserDataService.LoginUserAsync(LoginDto);
                if (result != null)
                {
                    NavigationManager.NavigateTo("/");
                }
            }
        }
    }
}
