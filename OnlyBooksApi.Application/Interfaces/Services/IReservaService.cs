using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.Enums;
using OnlyBooksApi.Core.Models.ViewModels;

namespace OnlyBooksApi.Application.Interfaces.Services
{
    public interface IReservaService
    {
        List<ReservaViewModel> GetAll();
        ReservaViewModel Create(CreateReservaDto entity);
        ReservaViewModel GetById(int id);
        ReservaViewModel UpdateStatus(int id, StatusReserva novoStatus);
        List<ReservaViewModel> GetByUserEmail(string email);
    }
}
