using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Models;
using FluentResults;
using System.Linq;

namespace FilmesAPI.Services
{
    public class SessaoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto AdicionaSessao(CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);

            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public ReadSessaoDto RecuperaSessaoPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if (sessao == null) return null;

            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public Result DeletaSessao(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if (sessao is null) return Result.Fail("Sessão não encontrada.");

            _context.Remove(sessao);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
