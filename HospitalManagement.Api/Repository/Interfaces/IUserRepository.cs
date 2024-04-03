using HospitalManagement.Shared.Dto;
using HospitalManagement.Shared.Entities;

namespace HospitalManagement.API.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<User?> LoginUserAsync(LoginDto loginDto);
        Task<IEnumerable<User>?> GetAllAsync();
    }
}
