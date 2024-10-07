using OnlyBooksApi.Core.Models;

namespace OnlyBooksApi.Application.Interfaces.Repositories
{
    public interface IEmprestimoRepository
    {
        IEnumerable<Emprestimo> GetAll();
        Emprestimo GetById(int id);
        Emprestimo GetAsNoTracking(int id);
        List<Emprestimo> GetList();
        void Add(Emprestimo emprestimo);
        void Update(Emprestimo emprestimo);
        void Delete(Emprestimo emprestimo);
    }
}
