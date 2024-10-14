using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.ViewModels;

namespace OnlyBooksApi.Application.Interfaces.Services
{
    public interface IGeneroLivroService
    {
        List<GeneroLivroViewModel> GetAll();
        GeneroLivroViewModel Create(GeneroLivroDto entity);
        GeneroLivroViewModel GetById(int id);
        GeneroLivroViewModel Update(int id, GeneroLivroDto entity);
        void Delete(int id);
    }
}
