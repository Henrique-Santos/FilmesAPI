using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Gerente;
using FilmesAPI.Models;
using FluentResults;
using System.Linq;

namespace FilmesAPI.Services
{
    public class GerenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadGerenteDto AdicionaGerente(CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);

            _context.Gerentes.Add(gerente);
            _context.SaveChanges();

            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public ReadGerenteDto RecuperaGerentePorId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if (gerente == null) return null;

            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public Result DeletaGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if (gerente is null) return Result.Fail("Gerente não encontrado.");

            _context.Remove(gerente);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
