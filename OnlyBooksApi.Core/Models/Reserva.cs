using OnlyBooksApi.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlyBooksApi.Core.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }
        public StatusReserva StatusReserva { get; set; } = StatusReserva.Pendente;
        public DateTime DataReserva { get; set; } = DateTime.Now;
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<ReservaLivro> ReservaLivros { get; set; }
    }
}
