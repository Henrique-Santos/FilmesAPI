using FilmesAPI.Data.Dtos.Cinema;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }


        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto readDto = _cinemaService.AdicionaCinema(cinemaDto);
            
            return CreatedAtAction(nameof(RecuperaCinemaPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDto> readDto = _cinemaService.RecuperaCinemas(nomeDoFilme);

            if (readDto == null) return NotFound();

            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemaPorId(int id)
        {
           ReadCinemaDto readDto = _cinemaService.RecuperaCinemaPorId(id);
            
            if (readDto == null) return NotFound();
            
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result resultado = _cinemaService.AtualizaCinema(id, cinemaDto);

            if (resultado.IsFailed) return NotFound();
            
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Result resultado = _cinemaService.DeletaCinema(id);

            if (resultado.IsFailed) return NotFound();

            return NoContent();
        }
    }
}
