using ClientesApp.Domain.Interfaces.Storage;
using ClientesApp.Infra.Data.MongoDB.Contexts;
using ClientesApp.Infra.Data.MongoDB.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Infra.Data.MongoDB.Extensions
{
    /// <summary>
    /// Classe de extensão para injeção de dependência do projeto MongoDB
    /// </summary>
    public static class MongoDBExtension
    {
        public static IServiceCollection AddMongoDBConfig(this IServiceCollection services, IConfiguration configuration)
        {
            //lendo a connectionstring do arquivo /appsettings
            var connectionString = configuration.GetConnectionString("ClientesAppMongoDB");

            //lendo o nome do banco de dados
            var databaseName = configuration.GetSection("MongoDBSettings:Database").Value;

            //fazendo a injeção de dependência para a classe de contexto
            services.AddSingleton(map => new MongoDBContext(connectionString, databaseName));

            //fazendo a injeção de dependência do storage
            services.AddScoped<IClienteStorage, ClienteStorage>();

            return services;
        }
    }
}
