using OnlyBooksApi.Core.Models.Enums;

namespace OnlyBooksApi.Core.Models.ViewModels
{
    public class CreateEmprestimoAsyncViewModel
    {
        public string Msg { get; set; }
        public int ReservaId { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
