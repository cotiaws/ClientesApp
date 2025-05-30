using ClientesApp.Domain.Commands;
using ClientesApp.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface para os métodos da camada de serviços de domínio
    /// </summary>
    public interface IClienteDomainService
    {
        Task<ClienteQuery> Create(ClienteCreateCommand command);
        Task<ClienteQuery> Update(ClienteUpdateCommand command);
        Task<ClienteQuery> Delete(ClienteDeleteCommand command);

        Task<List<ClienteQuery>> GetAll(int page, int pageSize);
        Task<ClienteQuery> GetById(Guid id);
    }
}
