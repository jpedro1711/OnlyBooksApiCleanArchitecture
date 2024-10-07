namespace OnlyBooksApi.Core.Models.Dtos
{
    public record CreateReservaDto
    {
        public int UsuarioId { get; set; }
        public List<int> LivrosIds { get; set; }
    }
}
