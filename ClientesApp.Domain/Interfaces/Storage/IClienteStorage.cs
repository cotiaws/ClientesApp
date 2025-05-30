using ClientesApp.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Interfaces.Storage
{
    /// <summary>
    /// Interface para abstração dos métodos de persistência de dados
    /// do bando do MongoDB (NoSQL) para cliente
    /// </summary>
    public interface IClienteStorage
    {
        Task Insert(ClienteQuery cliente); //inserir um cliente
        Task Update(ClienteQuery cliente); //atualizar um cliente
        Task Deactivate(Guid? id); //inativar um cliente
        Task<List<ClienteQuery>> FindAll(int page, int pageSize); //consulta por paginação
        Task<ClienteQuery> FindById(Guid? id); //buscar 1 cliente através do id
    }
}
