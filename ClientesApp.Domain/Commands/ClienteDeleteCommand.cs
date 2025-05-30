using ClientesApp.Domain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Commands
{
    /// <summary>
    /// Classe para representar comando de exclusão de cliente
    /// </summary>
    public class ClienteDeleteCommand : IRequest<ClienteQuery>
    {
        public Guid? Id { get; set; } //id do cliente
    }
}
