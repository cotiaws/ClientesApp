using AutoMapper;
using ClientesApp.Domain.Commands;
using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces.Repositories;
using ClientesApp.Domain.Notifications;
using ClientesApp.Domain.Queries;
using ClientesApp.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Handlers
{
    /// <summary>
    /// Processa as requisições de CREATE, UPDATE ou DELETE para cliente
    /// capturados pelo MediatR (enviados pelo comando 'send')
    /// </summary>
    public class ClienteRequestHandler (IClienteRepository clienteRepository, IMapper mapper, IMediator mediator)
        : IRequestHandler<ClienteCreateCommand, ClienteQuery>, //requisição de cadastro de cliente
          IRequestHandler<ClienteUpdateCommand, ClienteQuery>, //requisição de edição de cliente
          IRequestHandler<ClienteDeleteCommand, ClienteQuery>  //requisição de exclusão de cliente
    {
        public async Task<ClienteQuery> Handle(ClienteCreateCommand request, CancellationToken cancellationToken)
        {
            var cliente = mapper.Map<Cliente>(request);

            await clienteRepository.Insert(cliente);

            var clienteQuery = mapper.Map<ClienteQuery>(cliente);

            var notification = new ClienteNotification
            {
                Action = NotificationAction.Created,
                Cliente = clienteQuery
            };

            await mediator.Publish(notification); //enviando para o Notification Handler

            return clienteQuery;
        }

        public async Task<ClienteQuery> Handle(ClienteUpdateCommand request, CancellationToken cancellationToken)
        {
            var cliente = await clienteRepository.FindById(request.Id);
            if (cliente == null)
                throw new ApplicationException("Cliente não encontrado para edição.");

            cliente.Nome = request.Nome;
            cliente.Email = request.Email;
            cliente.Cpf = new Cpf(request.Cpf);
            cliente.DataHoraUltimaAlteracao = DateTime.Now;

            await clienteRepository.Update(cliente);

            var clienteQuery = mapper.Map<ClienteQuery>(cliente);

            var notification = new ClienteNotification
            {
                Action = NotificationAction.Updated,
                Cliente = clienteQuery
            };

            await mediator.Publish(notification); //enviando para o Notification Handler

            return clienteQuery;
        }

        public async Task<ClienteQuery> Handle(ClienteDeleteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await clienteRepository.FindById(request.Id);
            if (cliente == null)
                throw new ApplicationException("Cliente não encontrado para exclusão.");

            await clienteRepository.Deactivate(request.Id);

            var clienteQuery = mapper.Map<ClienteQuery>(cliente);
            clienteQuery.Ativo = false;

            var notification = new ClienteNotification
            {
                Action = NotificationAction.Deleted,
                Cliente = clienteQuery
            };

            await mediator.Publish(notification); //enviando para o Notification Handler

            return clienteQuery;
        }
    }
}
