using Microsoft.Extensions.DependencyInjection;
using SistemasSeguros.WebAPI.Application.Services;
using SistemasSeguros.WebAPI.Application.Services.SeguroCalculaMedia;
using SistemasSeguros.WebAPI.Application.Services.SeguroConsultar;
using SistemasSeguros.WebAPI.Application.Services.SeguroCriar;

namespace SistemasSeguros.WebAPI.Modules
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<Notification, Notification>();

            services.AddScoped<ISeguroCriarService, SeguroCriarService>();
            services.Decorate<ISeguroCriarService, SeguroCriarValidationService>();

            services.AddScoped<ISeguroConsultarService, SeguroConsultarService>();
            services.Decorate<ISeguroConsultarService, SeguroConsultarValidationService>();

            services.AddScoped<ISeguroCalculaMediaService, SeguroCalculaMediaService>();

            return services;
        }
    }
}
