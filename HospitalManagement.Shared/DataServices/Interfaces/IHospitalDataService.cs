using HospitalManagement.Shared.Entities;

namespace HospitalManagement.Shared.DataServices.Interfaces
{
    public interface IHospitalDataService
    {
        Task<Hospital?> GetByIdAsync(int id);
        Task<IEnumerable<Hospital>?> GetAllAsync();
        Task<int> Add(Hospital hospital);
    }
}
