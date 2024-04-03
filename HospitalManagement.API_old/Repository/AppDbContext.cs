using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace HospitalManagement.API.Repository
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;
        public AppDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AppDb");
        }
        public SqlConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
