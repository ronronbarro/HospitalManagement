using HospitalManagement.Shared.DataServices.Interfaces;
using HospitalManagement.Shared.Dto;
using HospitalManagement.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace HospitalManagement.Shared.DataServices.Implementations
{
    public class UserDataService : BaseDataService<User>, IUserDataService
    {
        public UserDataService(HttpClient httpClient) : base(httpClient)
        {

        }

        public async Task<IEnumerable<User>?> GetAllAsync()
        {
            return await _httpClient.GetJsonAsync<User[]>("user/all");
        }

        public async Task<User?> LoginUserAsync(LoginDto loginDto)
        {
            return await _httpClient.PostJsonAsync<User>("user/login", loginDto);
        }
    }
}
