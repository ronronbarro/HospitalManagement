using HospitalManagement.API.Repository;
using HospitalManagement.API.Repository.Implementations;
using HospitalManagement.API.Repository.Interfaces;

namespace HospitalManagement.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<AppDbContext>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IHospitalRepository, HospitalRepository>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }
    }
}
