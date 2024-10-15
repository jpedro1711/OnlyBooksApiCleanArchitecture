using Microsoft.AspNetCore.Http;

namespace OnlyBooksApi.Core.Models.Dtos
{
    public record CreateLivroDto
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int GeneroLivroId { get; set; }
        public IFormFile? fileImage { get; set; }
    }
}
