using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces.Storage;
using ClientesApp.Domain.Queries;
using ClientesApp.Infra.Data.MongoDB.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Infra.Data.MongoDB.Storage
{
    /// <summary>
    /// Implementar as operações no banco de dados 
    /// do MongoDB para a entidade Cliente
    /// </summary>
    public class ClienteStorage (MongoDBContext mongoDBContext) : IClienteStorage
    {
        public async Task Insert(ClienteQuery cliente)
        {
            //inserindo um cliente no banco de dados do MongoDB
            await mongoDBContext.Clientes.InsertOneAsync(cliente);
        }

        public async Task Update(ClienteQuery cliente)
        {
            //criando uma regra para filtrar o cliente pelo id
            var filter = Builders<ClienteQuery>.Filter.Eq(c => c.Id, cliente.Id);

            //substtuindo o registro (replace) baseado no filtro do id
            await mongoDBContext.Clientes.ReplaceOneAsync(filter, cliente);
        }

        public async Task Deactivate(Guid? id)
        {
            //criando uma regra para filtrar o cliente pelo id
            var filter = Builders<ClienteQuery>.Filter.Eq(c => c.Id, id);

            //atualizando somente o campo Ativo para valor falso
            var update = Builders<ClienteQuery>.Update.Set(c => c.Ativo, false);

            //executando a atualizando somente do campo Ativo baseano no filtro definido
            await mongoDBContext.Clientes.UpdateOneAsync(filter, update);
        }

        public async Task<List<ClienteQuery>> FindAll(int page, int pageSize)
        {
            //Calcular quantos registros serão trazidos com base nos parametros passados
            var skip = (page - 1) * pageSize;

            //criando um regra para filtrar somente clientes ativos
            var filter = Builders<ClienteQuery>.Filter.Eq(c => c.Ativo, true);

            //criando uma regra de ordenação por data de criação decrescente
            var sort = Builders<ClienteQuery>.Sort.Descending(c => c.DataHoraCriacao);

            //construindo a consulta no banco de dados
            return await mongoDBContext.Clientes
                    .Find(filter) //Regras de filtro (where)
                    .Sort(sort) //Regras de ordenação
                    .Skip(skip) //Intervalo da páginação
                    .Limit(pageSize) //Limite da paginação
                    .ToListAsync(); //Retornar uma lista com os resultados
        }

        public async Task<ClienteQuery> FindById(Guid? id)
        {
            //Criando os filtros para a consulta usando uma clausula AND
            var filter = Builders<ClienteQuery>.Filter.And( //Operador de junção (AND)
                    Builders<ClienteQuery>.Filter.Eq(c => c.Id, id), //primeira condição
                    Builders<ClienteQuery>.Filter.Eq(c => c.Ativo, true) //segunda condição
                );

            //Retornando 1 registro do banco de dados
            return await mongoDBContext.Clientes.Find(filter).FirstOrDefaultAsync();
        }
    }
}
