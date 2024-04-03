using Dapper;
using HospitalManagement.API.Repository.Interfaces;
using HospitalManagement.Shared.Dto;
using HospitalManagement.Shared.Entities;

namespace HospitalManagement.API.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<User>?> GetAllAsync()
        {

            IEnumerable<User>? hospital = null;

            var query = "SELECT * FROM dbo.Users";
            try
            {
                using (var connection = _appDbContext.CreateConnection())
                {
                    hospital = await connection.QueryAsync<User>(query);
                }
            }
            catch (Exception ex)
            {
            }

            return hospital;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            User? user = null;

            var query = "SELECT * FROM dbo.Users WHERE Id = @Id";
            try
            {
                using (var connection = _appDbContext.CreateConnection())
                {
                    user = await connection.QueryFirstOrDefaultAsync<User>(query, new { Id = id });
                }
            }
            catch (Exception)
            {
            }

            return user;
        }


        public async Task<User?> LoginUserAsync(LoginDto loginDto)
        {
            User? user = null;
            var query = "SELECT * FROM dbo.Users WHERE Username = @Username and Password = @Password";
            try
            {
                using (var connection = _appDbContext.CreateConnection())
                {
                    user = await connection.QueryFirstOrDefaultAsync<User>(query, loginDto);
                }
            }
            catch (Exception ex)
            {
            }

            return user;
        }
    }
}
