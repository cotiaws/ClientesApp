using ClientesApp.Domain.Queries;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Infra.Data.MongoDB.Contexts
{
    /// <summary>
    /// Classe de contexto para conexão com o banco de dados do MongoDB
    /// </summary>
    public class MongoDBContext
    {
        //Objeto que armazena a conexão com o banco de dados
        private readonly IMongoDatabase _mongoDatabase;

        //Construtor para criar a conexão com o banco do MongoDB
        public MongoDBContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _mongoDatabase = client.GetDatabase(databaseName);
        }

        //Mapeamento da collection para gravar os dados dos clientes
        public IMongoCollection<ClienteQuery> Clientes
            => _mongoDatabase.GetCollection<ClienteQuery>("clientes");
    }
}
