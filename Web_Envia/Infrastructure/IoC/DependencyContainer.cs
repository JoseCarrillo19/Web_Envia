using Microsoft.EntityFrameworkCore;
using Web_Envia.Domain.IRepository;
using Web_Envia.Infrastructure.Data;
using Web_Envia.Infrastructure.Repository;

namespace Web_Envia.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {

            string serverName = "(localdb)\\mssqllocaldb";
            string dataBaseName = "Web_Envia3.0";

            string connectionString = $"Server={serverName};Database={dataBaseName};Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;";

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<DbContext, ApplicationDbContext>();

            services.AddScoped<IGuidesRegistrationRepository, GuidesRegistrationRepository>();
            return services;
        }
    }
}
