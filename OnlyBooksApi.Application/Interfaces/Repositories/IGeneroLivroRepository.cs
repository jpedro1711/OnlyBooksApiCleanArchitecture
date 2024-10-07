using OnlyBooksApi.Core.Models;

namespace OnlyBooksApi.Application.Interfaces.Repositories
{
    public interface IGeneroLivroRepository
    {
        IEnumerable<GeneroLivro> GetAll();
        GeneroLivro GetById(int id);
        GeneroLivro GetAsNoTracking(int id);
        List<GeneroLivro> GetList();
        void Add(GeneroLivro genero);
        void Update(GeneroLivro genero);
        void Delete(GeneroLivro genero);
    }
}
