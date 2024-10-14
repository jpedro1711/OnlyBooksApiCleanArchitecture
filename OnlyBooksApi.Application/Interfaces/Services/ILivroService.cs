using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.Enums;
using OnlyBooksApi.Core.Models.ViewModels;

namespace OnlyBooksApi.Application.Interfaces.Services
{
    public interface ILivroService
    {
        List<LivroViewModel> GetAll();
        LivroViewModel Create(CreateLivroDto entity);
        LivroViewModel GetById(int id);
        LivroViewModel Update(int id, LivroDto entity);
        LivroViewModel AtualizarStatus(int id, StatusLivro novoStatus);
        LivroViewModel AvaliarLivro(int id, int novaAvaliacao);
        void Delete(int id);
    }
}
