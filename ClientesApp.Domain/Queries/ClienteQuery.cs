using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Queries
{
    /// <summary>
    /// Modelo de dados para consulta de clientes (leitura)
    /// </summary>
    public class ClienteQuery
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid? Id { get; set; } //id do cliente
        public string? Nome { get; set; } //nome do cliente
        public string? Email { get; set; } //email do cliente
        public string? Cpf { get; set; } //cpf do cliente
        public DateTime? DataHoraCriacao { get; set; } //data e hora do cadastro
        public DateTime? DataHoraUltimaAlteracao { get; set; } //data e hora da ultima alteração
        public bool? Ativo { get; set; } //flag para ativar ou inativar o registro
    }
}

