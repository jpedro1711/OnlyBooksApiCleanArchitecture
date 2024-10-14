using AutoMapper;
using OnlyBooksApi.Application.Interfaces.Repositories;
using OnlyBooksApi.Application.Interfaces.Services;
using OnlyBooksApi.Core.Exceptions;
using OnlyBooksApi.Core.Models;
using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.Enums;
using OnlyBooksApi.Core.Models.ViewModels;

namespace OnlyBooksApi.Application.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _repository;
        private readonly ILivroService _livroService;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        public ReservaService(IReservaRepository repository, IMapper mapper, ILivroService livroService, IUsuarioService usuarioService)
        {
            _repository = repository;
            _mapper = mapper;
            _livroService = livroService;
            _usuarioService = usuarioService;
        }

        public ReservaViewModel Create(CreateReservaDto entity)
        {
            var usuarioDto = _usuarioService.GetById(entity.UsuarioId);

            if (usuarioDto == null)
            {
                throw new NotFoundException("Usuário não encontrado");
            }

            Reserva reserva = new Reserva { UsuarioId = usuarioDto.Id };

            var livros = _livroService.GetAll()
                .Where(livro => entity.LivrosIds.Contains(livro.Id))
                .ToList();

            var reservasLivros = livros.Select(livro => new ReservaLivro
            {
                Reserva = reserva,
                LivroId = livro.Id
            }).ToList();

            reserva.ReservaLivros = reservasLivros;

            _repository.Add(reserva);

            return _mapper.Map<ReservaViewModel>(reserva);
        }

        public List<ReservaViewModel> GetAll()
        {
            IEnumerable<Reserva> reservas = _repository.GetAll();

            List<ReservaViewModel> reservaDtos = _mapper.Map<List<ReservaViewModel>>(reservas);

            return reservaDtos;
        }

        public List<ReservaViewModel> GetByUserEmail(string email)
        {
            IQueryable<Reserva> reservas = _repository.GetByuserEmail(email);

            return _mapper.Map<List<ReservaViewModel>>(reservas);
        }

        public ReservaViewModel GetById(int id)
        {
            Reserva reserva = _repository.GetById(id);

            if (reserva != null)
            {
                return _mapper.Map<ReservaViewModel>(reserva);
            }

            throw new NotFoundException("Reserva não encontrada");
        }

        public ReservaViewModel UpdateStatus(int id, StatusReserva novoStatus)
        {
            var reservaExistente = _repository.GetById(id);

            if (reservaExistente != null)
            {
                reservaExistente.StatusReserva = novoStatus;
                _repository.Update(reservaExistente);
                return _mapper.Map<ReservaViewModel>(reservaExistente);
            }

            throw new NotFoundException("Reserva não encontrada");
        }
    }
}
