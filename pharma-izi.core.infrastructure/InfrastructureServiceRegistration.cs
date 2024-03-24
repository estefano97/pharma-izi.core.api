using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using pharma_izi.core.infrastructure.Database;
using pharma_izi.core.infrastructure.helpers.services;

namespace pharma_izi.core.infrastructure
{
    public static class InfrastructureServiceRegistration
    {

        public static IServiceCollection AddInInfrestructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IClaimsManager, ClaimsManager>();
            services.AddSingleton<PharmaIziContext>();
            return services;
        }

    }
}