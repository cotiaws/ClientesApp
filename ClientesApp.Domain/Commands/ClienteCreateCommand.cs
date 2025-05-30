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
    /// Classe para representar comando de cadastro de cliente
    /// </summary>
    public class ClienteCreateCommand : IRequest<ClienteQuery>
    {
        public string? Nome { get; set; } //nome do cliente
        public string? Email { get; set; } //email do cliente
        public string? Cpf { get; set; } //cpf do cliente
    }
}
