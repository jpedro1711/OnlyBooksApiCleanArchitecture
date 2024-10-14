using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.ViewModels;

namespace OnlyBooksApi.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        List<UsuarioViewModel> GetAll();
        UsuarioViewModel Create(CreateOrUpdateUsuarioDto entity);
        UsuarioViewModel GetById(int id);
        UsuarioViewModel Update(int id, CreateOrUpdateUsuarioDto entity);
        void Delete(int id);
    }
}
