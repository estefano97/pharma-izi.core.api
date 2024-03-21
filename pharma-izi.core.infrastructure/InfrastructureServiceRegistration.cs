using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using pharma_izi.core.infrastructure.Database;
using pharma_izi.core.infrastructure.helpers;

namespace pharma_izi.core.infrastructure
{
    public static class InfrastructureServiceRegistration
    {

        public static IServiceCollection AddInInfrestructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddSingleton<PharmaIziContext>();
            return services;
        }

    }
}