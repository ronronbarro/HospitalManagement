using HospitalManagement.Shared.Entities;

namespace HospitalManagement.API.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
    }
}
