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
                var query = "INSERT INTO dbo.Hospital " +
                    " (hospital_id, name, is_active, account_manager, plan_assigned)" +
                    " VALUES" +
                    " (@hospital_id, @name, @is_active, @account_manager, @plan_assigned)";

                using (var connection = _appDbContext.CreateConnection())
                {
                    rowsAffected = await connection.ExecuteAsync(query, hospital);
                }
            }
            catch (Exception ex)
            { }
            return rowsAffected;
        }

        public async Task<IEnumerable<Hospital>?> GetAllAsync()
        {
            IEnumerable<Hospital>? hospital = null;

            var query = "SELECT * FROM dbo.Hospital";
            try
            {
                using (var connection = _appDbContext.CreateConnection())
                {
                    hospital = await connection.QueryAsync<Hospital>(query);
                }
            }
            catch (Exception ex)
            {
            }

            return hospital;
        }

        public async Task<Hospital?> GetByIdAsync(int id)
        {
            Hospital? hospital = null;

            var query = "SELECT * FROM dbo.Hospital WHERE Id = @Id";
            try
            {
                using (var connection = _appDbContext.CreateConnection())
                {
                    hospital = await connection.QueryFirstOrDefaultAsync<Hospital>(query, new { Id = id });
                }
            }
            catch (Exception ex)
            {
            }

            return hospital;
        }
    }
}
