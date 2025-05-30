using ClientesApp.Domain.Interfaces.Repositories;
using ClientesApp.Infra.Data.SqlServer.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Infra.Data.SqlServer.Extensions
{
    /// <summary>
    /// Classe de extensão para injeção de dependência do SqlServer
    /// </summary>
    public static class SqlServerConnectionExtension
    {
        public static IServiceCollection AddSqlServerConfig(this IServiceCollection services, IConfiguration configuration)
        {
            //capturando a connectionstring do banco de dados
            var connectionString = configuration.GetConnectionString("ClientesAppSqlServer");

            //injeção de dependência do clienterepository
            services.AddScoped<IClienteRepository>(map => new ClienteRepository(new SqlConnection(connectionString)));

            return services;
        }
    }
}
