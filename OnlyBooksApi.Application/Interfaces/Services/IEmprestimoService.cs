using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.Enums;

namespace OnlyBooksApi.Application.Interfaces.Services
{
    public interface IEmprestimoService
    {
        List<EmprestimoDto> GetAll();
        List<LivroResponseDto> GetLivrosEmprestados();
        Task<BaseMessageResponse> CreateAsync(CreateEmprestimoDto entity);
        EmprestimoDto GetById(int id);
        EmprestimoDto UpdateStatus(int id, StatusEmprestimo novoStatus);
    }
}
