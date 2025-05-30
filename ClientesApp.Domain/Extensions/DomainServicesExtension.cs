using ClientesApp.Domain.Interfaces.Services;
using ClientesApp.Domain.Profiles;
using ClientesApp.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Extensions
{
    /// <summary>
    /// Classe para configuração das injeções de dependência do domínio
    /// </summary>
    public static class DomainServicesExtension
    {
        public static IServiceCollection AddDomainServicesConfig(this IServiceCollection services)
        {
            //configurando o MediatR
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()); 
            });

            //configurando o AutoMapper
            services.AddAutoMapper(typeof(ClienteProfile));

            services.AddScoped<IClienteDomainService, ClienteDomainService>();

            return services;
        }
    }
}
