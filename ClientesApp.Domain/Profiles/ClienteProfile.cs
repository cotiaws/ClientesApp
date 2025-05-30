using AutoMapper;
using ClientesApp.Domain.Commands;
using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Queries;
using ClientesApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Profiles
{
    /// <summary>
    /// Classe para configuração dos mapeamentos de cópia de dados do AutoMapper
    /// para cliente (Commands, Queries ou Entities)
    /// </summary>
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            //Create Command -> Entity
            CreateMap<ClienteCreateCommand, Cliente>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => new Cpf(src.Cpf)))
                .ForMember(dest => dest.DataHoraCriacao, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.DataHoraUltimaAlteracao, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));

            //Entity -> Query
            CreateMap<Cliente, ClienteQuery>()
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf.Numero));
        }
    }
}
