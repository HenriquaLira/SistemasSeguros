using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasSeguros.WebAPI.Modules
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAuthentication(
        this IServiceCollection services,
        IConfiguration configuration)
        {

            services
                .AddAuthentication("Bearer");

            return services;
        }
    }
}
