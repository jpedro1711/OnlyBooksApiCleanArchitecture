using AutoMapper;
using MassTransit;
using Microsoft.Extensions.Configuration;
using OnlyBooksApi.Application.Interfaces.Repositories;
using OnlyBooksApi.Application.Interfaces.Services;
using OnlyBooksApi.Core.Constants;
using OnlyBooksApi.Core.Exceptions;
using OnlyBooksApi.Core.Models;
using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.Enums;
using OnlyBooksApi.Core.Models.ViewModels;

namespace OnlyBooksApi.Application.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _repository;
        private readonly IReservaRepository _reservaRepository;
        private readonly IReservaService _reservaService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private IBus _bus;

        public EmprestimoService(IEmprestimoRepository repository, IMapper mapper, IReservaService reservaService, IBus bus)
        {
            _repository = repository;
            _mapper = mapper;
            _reservaService = reservaService;
            _bus = bus;
        }

        public async Task<CreateEmprestimoAsyncViewModel> CreateAsync(CreateEmprestimoDto entity)
        {

            var reserva = _reservaService.GetById(entity.ReservaId);

            if (reserva == null)
            {
                throw new NotFoundException($"Reserva não encontrada com ID {entity.ReservaId}");
            }

            var sendEndpoint = await _bus.GetSendEndpoint(new Uri(QueueNames.EmprestimosQueue));
            await sendEndpoint.Send(entity);

            _reservaService.UpdateStatus((int)reserva.Id, StatusReserva.Confirmada);

            return new CreateEmprestimoAsyncViewModel { Msg = "Sua requisição para criação de empréstimo está sendo processada", ReservaId = entity.ReservaId, DataDevolucao = entity.DataDevolucao};
        }

        public List<EmprestimoViewModel> GetAll()
        {
            IEnumerable<Emprestimo> emprestimos = _repository.GetAll();

            List<EmprestimoViewModel> emprestimosDtos = _mapper.Map<List<EmprestimoViewModel>>(emprestimos);

            return emprestimosDtos;
        }

        public EmprestimoViewModel GetById(int id)
        {
            Emprestimo emprestimo = _repository.GetById(id);

            if (emprestimo != null)
            {
                return _mapper.Map<EmprestimoViewModel>(emprestimo);
            }

            throw new NotFoundException("Empréstimo não encontrado");
        }

        public EmprestimoViewModel UpdateStatus(int id, StatusEmprestimo novoStatus)
        {
            var emprestimoExistente = _repository.GetById(id);

            if (emprestimoExistente != null)
            {
                emprestimoExistente.StatusEmprestimo = novoStatus;
                _repository.Update(emprestimoExistente);
                return _mapper.Map<EmprestimoViewModel>(emprestimoExistente);
            }

            throw new NotFoundException("Empréstimo não encontrado");
        }
    }
}
