using ClientesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface para construção de um repositório SQL
    /// </summary>
    public interface IClienteRepository
    {
        Task Insert(Cliente cliente); //inserir um cliente no banco de dados
        Task Update(Cliente cliente); //atualizar um cliente no banco de dados
        Task Deactivate(Guid? id); //inativar um cliente no banco de dados
        Task<Cliente> FindById(Guid? id); //buscar 1 cliente através do id
    }
}
