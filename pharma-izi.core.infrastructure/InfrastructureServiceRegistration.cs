using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace pharma_izi.core.infrastructure
{
    public static class InfrastructureServiceRegistration
    {

        public static IServiceCollection AddInInfrestructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IEstadosReporte, EstadosReporteService>();
           // services.AddSingleton<TrainingBrokerContext>();
            return services;
        }

    }
}