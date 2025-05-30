using ClientesApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Entities
{
    /// <summary>
    /// Modelo de entidade para Cliente
    /// </summary>
    public class Cliente
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public Cpf? Cpf { get; set; }
        public DateTime? DataHoraCriacao { get; set; }
        public DateTime? DataHoraUltimaAlteracao { get; set; }
        public bool? Ativo { get; set; }
    }
}
