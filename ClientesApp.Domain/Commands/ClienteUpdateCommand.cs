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
    /// Classe para representar comando de edição de cliente
    /// </summary>
    public class ClienteUpdateCommand : IRequest<ClienteQuery>
    {
        public Guid? Id { get; set; } //Id do cliente
        public string? Nome { get; set; } //Nome do cliente
        public string? Email { get; set; } //Email do cliente
        public string? Cpf { get; set; } //Cpf do cliente
    }
}
