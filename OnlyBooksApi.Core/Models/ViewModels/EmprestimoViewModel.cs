using OnlyBooksApi.Core.Models.Enums;

namespace OnlyBooksApi.Core.Models.ViewModels
{
    public class EmprestimoViewModel
    {
        public int Id { get; set; }
        public int ReservaId { get; set; }
        public DateTime DataDevolucao { get; set; }
        public StatusEmprestimo StatusEmprestimo { get; set; }
    }
}
