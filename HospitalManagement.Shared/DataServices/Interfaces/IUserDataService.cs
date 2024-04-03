using HospitalManagement.Shared.Dto;
using HospitalManagement.Shared.Entities;

namespace HospitalManagement.Shared.DataServices.Interfaces
{
    public interface IUserDataService
    {
        Task<User?> LoginUserAsync(LoginDto loginDto);

        Task<IEnumerable<User>?> GetAllAsync();
    }
}
