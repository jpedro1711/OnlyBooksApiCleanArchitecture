using OnlyBooksApi.Core.Models;

namespace OnlyBooksApi.Application.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
        List<Usuario> GetList();
        void Add(Usuario livro);
        void Update(Usuario livro);
        void Delete(Usuario livro);
    }
}
