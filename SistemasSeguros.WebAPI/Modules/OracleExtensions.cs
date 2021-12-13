using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using SistemasSeguros.Infrastructure;
using SistemasSeguros.Infrastructure.Repositories;

namespace SistemasSeguros.WebAPI.Modules
{
    public static class OracleExtensions
    {
       public static IServiceCollection AddOracle(
       this IServiceCollection services,
       IConfiguration configuration)
        {
            //IFeatureManager featureManager = services
            //    .BuildServiceProvider()
            //    .GetRequiredService<IFeatureManager>();

            services.AddDbContext<SisSeguroContext>(
                    options => options.UseOracle(
                        configuration.GetValue<string>("PersistenceModule:DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISeguroRepository, SeguroRepository>();

            return services;
        }
    }
}
