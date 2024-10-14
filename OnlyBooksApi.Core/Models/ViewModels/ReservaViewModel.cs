using OnlyBooksApi.Core.Models.Enums;

namespace OnlyBooksApi.Core.Models.ViewModels
{
    public class ReservaViewModel
    {
        public int? Id { get; set; }
        public StatusReserva StatusReserva { get; set; }
        public DateTime DataReserva { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public List<Livro> Livros { get; set; }
    }
}
