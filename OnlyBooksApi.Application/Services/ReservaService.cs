using AutoMapper;
using OnlyBooksApi.Application.Interfaces.Repositories;
using OnlyBooksApi.Application.Interfaces.Services;
using OnlyBooksApi.Core.Exceptions;
using OnlyBooksApi.Core.Models;
using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.Enums;

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

        public ReservaDto Create(CreateReservaDto entity)
        {
            // fix
            var usuarioDto = _usuarioService.GetById(entity.UsuarioId);

            if (usuarioDto == null)
            {
                throw new UsuarioException("Usuário inválido");
            }

            Reserva reserva = new Reserva { UsuarioId = usuarioDto.Id };
            _repository.Add(reserva);


            foreach (var livroId in entity.LivrosIds)
            {
                try
                {
                    Livro livro = _mapper.Map<Livro>(_livroService.GetById(livroId));
                    livro.Id = livroId;

                    reserva.Livros.Add(livro);
                }
                catch (LivroException ex)
                {
                    continue;
                }
            }

            return _mapper.Map<ReservaDto>(reserva);
        }

        public List<ReservaDto> GetAll()
        {
            IEnumerable<Reserva> reservas = _repository.GetAll();

            List<ReservaDto> reservaDtos = _mapper.Map<List<ReservaDto>>(reservas);

            return reservaDtos;
        }

        public List<ReservaDto> GetByUserEmail(string email)
        {
            IQueryable<Reserva> reservas = _repository.GetByuserEmail(email);

            return _mapper.Map<List<ReservaDto>>(reservas);
        }

        public ReservaDto GetById(int id)
        {
            Reserva reserva = _repository.GetById(id);

            if (reserva != null)
            {
                return _mapper.Map<ReservaDto>(reserva);
            }

            throw new ReservaException("Reserva não encontrada");
        }

        public ReservaDto UpdateStatus(int id, StatusReserva novoStatus)
        {
            var reservaExistente = _repository.GetById(id);

            if (reservaExistente != null)
            {
                reservaExistente.StatusReserva = novoStatus;
                _repository.Update(reservaExistente);
                return _mapper.Map<ReservaDto>(reservaExistente);
            }

            throw new ReservaException("Reserva não encontrada");
        }
    }
}
