using OnlyBooksApi.Core.Models;

namespace OnlyBooksApi.Application.Interfaces.Repositories
{
    public interface ILivroRepository
    {
        IEnumerable<Livro> GetAll();
        Livro GetById(int id);
        Livro GetAsNoTracking(int id);
        List<Livro> GetList();
        void Add(Livro livro);
        void Update(Livro livro);
        void Delete(Livro livro);
    }
}
