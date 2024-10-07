using OnlyBooksApi.Core.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlyBooksApi.Core.Models.Dtos
{
    public record EmprestimoDto
    {
        public int Id { get; set; }
        public int ReservaId { get; set; }
        public DateTime DataDevolucao { get; set; }
        public StatusEmprestimo StatusEmprestimo { get; set; }
    }
}
