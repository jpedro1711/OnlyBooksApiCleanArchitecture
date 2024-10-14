namespace OnlyBooksApi.Core.Models
{
    public class ReservaLivro
    {
        public int ReservaId { get; set; }
        public Reserva Reserva { get; set; }
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
    }
}
