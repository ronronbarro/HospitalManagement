using HospitalManagement.Shared.DataServices.Interfaces;
using HospitalManagement.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace HospitalManagement.Shared.DataServices.Implementations
{
    public class HospitalDataService : BaseDataService<Hospital>, IHospitalDataService
    {
        public HospitalDataService(HttpClient httpClient) : base(httpClient)
        {

        }

        public async Task<int> Add(Hospital hospital)
        {
            return await _httpClient.PostJsonAsync<int>("hospital/add", hospital);
        }

        public async Task<IEnumerable<Hospital>?> GetAllAsync()
        {
            return await _httpClient.GetJsonAsync<Hospital[]>("hospital/all");
        }

        public async Task<Hospital?> GetByIdAsync(int id)
        {
            return await GetByIdAsync("hospital", id);
        }
    }
}
