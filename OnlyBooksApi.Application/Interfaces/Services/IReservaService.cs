using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.Enums;

namespace OnlyBooksApi.Application.Interfaces.Services
{
    public interface IReservaService
    {
        List<ReservaDto> GetAll();
        ReservaDto Create(CreateReservaDto entity);
        ReservaDto GetById(int id);
        ReservaDto UpdateStatus(int id, StatusReserva novoStatus);
        List<ReservaDto> GetByUserEmail(string email);
    }
}
