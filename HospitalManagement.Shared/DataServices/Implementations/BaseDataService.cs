using Microsoft.AspNetCore.Components;

namespace HospitalManagement.Shared.DataServices.Implementations
{
    public abstract class BaseDataService<T>
    {
        protected readonly HttpClient _httpClient;
        protected BaseDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> AddAsync(string apiEndpoint, T entity)
        {
            return await _httpClient.PostJsonAsync<T>(apiEndpoint, entity);
        }

        public async Task<T> GetByIdAsync(string apiEndpoint, int id)
        {
            return await _httpClient.GetJsonAsync<T>($"{apiEndpoint}/{id}");
        }


    }
}
