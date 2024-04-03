using Dapper;
using HospitalManagement.API.Repository.Interfaces;
using HospitalManagement.Shared.Entities;

namespace HospitalManagement.API.Repository.Implementations
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly AppDbContext _appDbContext;
        public HospitalRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<int> Add(Hospital hospital)
        {
            int rowsAffected = 0;

            try
            {
                var query = "INSERT INTO dbo.Hospitals " +
                    " (hospital_id, name, is_active, account_manager, plan)" +
                    " VALUES" +
                    " (@hospital_id, @name, @is_active, @account_manager, @plan)";

                using (var connection = _appDbContext.CreateConnection())
                {
                    rowsAffected = await connection.ExecuteAsync(query, hospital);
                }
            }
            catch (Exception)
            { }
            return rowsAffected;
        }

        public async Task<Hospital?> GetByIdAsync(int id)
        {
            Hospital? hospital = null;

            var query = "SELECT * FROM dbo.Hospitals WHERE Id = @Id";
            try
            {
                using (var connection = _appDbContext.CreateConnection())
                {
                    hospital = await connection.QueryFirstOrDefaultAsync<Hospital>(query, new { Id = id });
                }
            }
            catch (Exception)
            {
            }

            return hospital;
        }
    }
}
