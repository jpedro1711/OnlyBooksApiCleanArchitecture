using OnlyBooksApi.Core.Models.Enums;

namespace OnlyBooksApi.Core.Models.Dtos
{
    public record CreateOrUpdateUsuarioDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}
