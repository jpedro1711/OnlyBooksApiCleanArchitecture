using OnlyBooksApi.Core.Models;
using OnlyBooksApi.Core.Models.Enums;

namespace OnlyBooksApi.Core.Models.Dtos
{
    public class ReservaDto
    {
        public int? Id { get; set; }
        public StatusReserva StatusReserva { get; set; }
        public DateTime DataReserva { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public List<Livro> Livros { get; set; }
    }
}
