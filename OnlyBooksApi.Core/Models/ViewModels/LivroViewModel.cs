using OnlyBooksApi.Core.Models.Enums;

namespace OnlyBooksApi.Core.Models.ViewModels
{
    public class LivroViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public StatusLivro Status { get; set; }
        public string? ImageUrl { get; set; }
        public double NotaAvaliacao { get; set; }
        public int? totalAvaliações { get; set; }
        public int? SomaTotalAvaliaçoes { get; set; }
        public GeneroLivro? Genero { get; set; }
        public List<Reserva> Reservas { get; set; }
    }
}
