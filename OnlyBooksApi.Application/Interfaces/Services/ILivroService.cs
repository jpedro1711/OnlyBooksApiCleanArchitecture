using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.Enums;

namespace OnlyBooksApi.Application.Interfaces.Services
{
    public interface ILivroService
    {
        List<LivroResponseDto> GetAll();
        LivroResponseDto Create(CreateLivroDto entity);
        LivroResponseDto GetById(int id);
        LivroResponseDto Update(int id, LivroDto entity);
        LivroResponseDto AtualizarStatus(int id, StatusLivro novoStatus);
        LivroResponseDto AvaliarLivro(int id, int novaAvaliacao);
        void Delete(int id);
    }
}
