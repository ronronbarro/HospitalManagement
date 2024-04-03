using HospitalManagement.Shared.DataServices.Interfaces;
using HospitalManagement.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace HospitalManagement.Blazor.Server.Components
{
    public partial class HospitalManagement
    {
        [Inject] private IHospitalDataService? HospitalDataService { get; set; }
        [Inject] private IUserDataService? UserDataService { get; set; }

        Hospital Hospital = new Hospital();
        List<Hospital>? Hospitals { get; set; } = new List<Hospital>();
        List<User>? Users { get; set; } = new List<User>();
        List<string>? Plans { get; set; } = new List<string> { "Starter", "Premium" };
        bool showModal = false;
        protected override async Task OnInitializedAsync()
        {
            var hospitals = await HospitalDataService.GetAllAsync();
            Hospitals = hospitals.ToList();
            var users = await UserDataService.GetAllAsync();
            Users = users.ToList();

        }

        private void ShowModal()
        {
            showModal = true;
            StateHasChanged();
        }
        private void OnClose()
        {
            showModal = false;
            StateHasChanged();
        }

        private async Task OnSave()
        {
            int rowsAffected = await HospitalDataService.Add(Hospital);
            if (rowsAffected > 0)
            {
                Hospitals.Add(Hospital);
            }
            showModal = false;
            await InvokeAsync(StateHasChanged);
        }
    }
}
