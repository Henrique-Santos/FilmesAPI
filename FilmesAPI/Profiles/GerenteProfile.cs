using AutoMapper;
using FilmesAPI.Data.Dtos.Gerente;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>()
                .ForMember(gerente => gerente.Cinemas, options => options
                .MapFrom(gerente => gerente.Cinemas.Select
                (cinema => new { cinema.Id, cinema.Nome, cinema.Endereco, cinema.EnderecoId })));
        }
    }
}
