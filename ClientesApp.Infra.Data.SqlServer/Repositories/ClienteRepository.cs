using Azure.Core;
using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces.Repositories;
using ClientesApp.Domain.ValueObjects;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Infra.Data.SqlServer.Repositories
{
    /// <summary>
    /// Implementação do repositório de cliente
    /// </summary>
    public class ClienteRepository(SqlConnection connection) : IClienteRepository
    {
        public async Task Insert(Cliente cliente)
        {
            var query = @"
                INSERT INTO Cliente(Id, Nome, Email, Cpf, DataHoraCriacao, DataHoraUltimaAlteracao, Ativo)
                VALUES(@Id, @Nome, @Email, @Cpf, @DataHoraCriacao, @DataHoraUltimaAlteracao, @Ativo)
            ";

            await connection.ExecuteAsync(query,
            new
            {
                cliente.Id,
                cliente.Nome,
                cliente.Email,
                Cpf = cliente.Cpf?.Numero,
                cliente.DataHoraCriacao,
                cliente.DataHoraUltimaAlteracao,
                cliente.Ativo
            });
        }

        public async Task Update(Cliente cliente)
        {
            var query = @"
                UPDATE Cliente SET 
                    Nome = @Nome, Email = @Email, Cpf = @Cpf, DataHoraUltimaAlteracao = @DataHoraUltimaAlteracao
                WHERE
                    Id = @Id
            ";

            await connection.ExecuteAsync(query,
            new
            {
                cliente.Id,
                cliente.Nome,
                cliente.Email,
                Cpf = cliente.Cpf?.Numero,
                cliente.DataHoraUltimaAlteracao
            });
        }

        public async Task Deactivate(Guid? id)
        {
            var query = @"
                UPDATE Cliente SET 
                    Ativo = 0
                WHERE
                    Id = @Id
            ";

            await connection.ExecuteAsync(query, new { id });
        }

        public async Task<Cliente> FindById(Guid? id)
        {
            var query = @"
                SELECT Id, Nome, Email, Cpf, DataHoraCriacao, DataHoraUltimaAlteracao, Ativo
                FROM Cliente
                WHERE Id = @Id
            ";

            var result = await connection.QueryFirstOrDefaultAsync(query, new { id });

            if (result == null) return null;

            return new Cliente
            {
                Id = result.Id,
                Nome = result.Nome,
                Email = result.Email,
                Cpf = new Cpf(result.Cpf),
                DataHoraCriacao = result.DataHoraCriacao,
                DataHoraUltimaAlteracao = result.DataHoraUltimaAlteracao,
                Ativo = result.Ativo
            };
        }
    }
}
