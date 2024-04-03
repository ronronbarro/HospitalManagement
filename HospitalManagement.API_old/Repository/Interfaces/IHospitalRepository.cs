using HospitalManagement.Shared.Entities;

namespace HospitalManagement.API.Repository.Interfaces
{
    public interface IHospitalRepository
    {
        Task<Hospital?> GetByIdAsync(int id);

        Task<int> Add(Hospital hospital);

    }
}
