using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class CreateFilmeDto
    {
        [Required(ErrorMessage = "O campo Titulo é obrigatório.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo Diretor é obrigatório.")]
        public string Diretor { get; set; }

        [StringLength(30, ErrorMessage = "O campo Genero deve ter no máximo 30 caracteres.")]
        public string Genero { get; set; }

        [Range(1, 200, ErrorMessage = "A Duracao deve ter no minimo 1 e no máximo 200 minutos.")]
        public int Duracao { get; set; }
    }
}
