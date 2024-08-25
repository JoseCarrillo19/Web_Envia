using Web_Envia.Application.IServices;
using Web_Envia.Application.Services;

namespace Web_Envia.Application.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IGuidesRegistrationServices, GuidesRegistrationServices>();
            return services;
        }
    }
}
