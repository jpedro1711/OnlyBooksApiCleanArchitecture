using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.Enums;
using OnlyBooksApi.Core.Models.ViewModels;

namespace OnlyBooksApi.Application.Interfaces.Services
{
    public interface IEmprestimoService
    {
        List<EmprestimoViewModel> GetAll();
        Task<CreateEmprestimoAsyncViewModel> CreateAsync(CreateEmprestimoDto entity);
        EmprestimoViewModel GetById(int id);
        EmprestimoViewModel UpdateStatus(int id, StatusEmprestimo novoStatus);
    }
}
