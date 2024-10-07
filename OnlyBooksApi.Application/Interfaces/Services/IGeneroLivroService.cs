using OnlyBooksApi.Core.Models.Dtos;

namespace OnlyBooksApi.Application.Interfaces.Services
{
    public interface IGeneroLivroService
    {
        List<GeneroLivroResponseDto> GetAll();
        GeneroLivroResponseDto Create(GeneroLivroDto entity);
        GeneroLivroResponseDto GetById(int id);
        GeneroLivroResponseDto Update(int id, GeneroLivroDto entity);
        void Delete(int id);
    }
}
