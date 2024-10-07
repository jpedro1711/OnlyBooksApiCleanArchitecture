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

        public async Task<BaseMessageResponse> CreateAsync(CreateEmprestimoDto entity)
        {
            try
            {
                var sendEndpoint = await _bus.GetSendEndpoint(new Uri(QueueNames.EmprestimosQueue));
                await sendEndpoint.Send(entity);

                return new BaseMessageResponse("Sua requisição para criação de empréstimo está sendo processada");
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao publicar mensagem na fila");
            }

        }

        public List<EmprestimoDto> GetAll()
        {
            IEnumerable<Emprestimo> emprestimos = _repository.GetAll();

            List<EmprestimoDto> emprestimosDtos = _mapper.Map<List<EmprestimoDto>>(emprestimos);

            return emprestimosDtos;
        }

        public List<LivroResponseDto> GetLivrosEmprestados()
        {
            IEnumerable<Emprestimo> emprestimosAtivosOuAtrasados = _repository.GetAll()
                                                .Where(e => e.StatusEmprestimo == StatusEmprestimo.Ativo || e.StatusEmprestimo == StatusEmprestimo.Atrasado);

            List<LivroResponseDto> livros = new();

            foreach (Emprestimo e in emprestimosAtivosOuAtrasados)
            {
                List<Livro> livrosEmp = e.Reserva.Livros;

                foreach (Livro item in livrosEmp)
                {
                    livros.Add(_mapper.Map<LivroResponseDto>(item));
                }
            }

            return livros;

        }

        public EmprestimoDto GetById(int id)
        {
            Emprestimo emprestimo = _repository.GetById(id);

            if (emprestimo != null)
            {
                return _mapper.Map<EmprestimoDto>(emprestimo);
            }

            throw new EmprestimoException("Empréstimo não encontrado");
        }

        public EmprestimoDto UpdateStatus(int id, StatusEmprestimo novoStatus)
        {
            var emprestimoExistente = _repository.GetById(id);

            if (emprestimoExistente != null)
            {
                emprestimoExistente.StatusEmprestimo = novoStatus;
                _repository.Update(emprestimoExistente);
                return _mapper.Map<EmprestimoDto>(emprestimoExistente);
            }

            throw new EmprestimoException("Empréstimo não encontrado");
        }
    }
}
