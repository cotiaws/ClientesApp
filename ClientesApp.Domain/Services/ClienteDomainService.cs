using ClientesApp.Domain.Commands;
using ClientesApp.Domain.Interfaces.Services;
using ClientesApp.Domain.Interfaces.Storage;
using ClientesApp.Domain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Services
{
    /// <summary>
    /// Implementação dos serviços de domínio de cliente
    /// </summary>
    public class ClienteDomainService (IMediator mediator, IClienteStorage clienteStorage) : IClienteDomainService
    {
        public async Task<ClienteQuery> Create(ClienteCreateCommand command)
        {
            return await mediator.Send(command);
        }

        public async Task<ClienteQuery> Update(ClienteUpdateCommand command)
        {
            return await mediator.Send(command);
        }

        public async Task<ClienteQuery> Delete(ClienteDeleteCommand command)
        {
            return await mediator.Send(command);
        }

        public async Task<List<ClienteQuery>> GetAll(int page, int pageSize)
        {
            return await clienteStorage.FindAll(page, pageSize);
        }

        public async Task<ClienteQuery> GetById(Guid id)
        {
            return await clienteStorage.FindById(id);
        }
    }
}
