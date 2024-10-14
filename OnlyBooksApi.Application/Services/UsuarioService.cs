using AutoMapper;
using OnlyBooksApi.Application.Interfaces.Repositories;
using OnlyBooksApi.Application.Interfaces.Services;
using OnlyBooksApi.Core.Exceptions;
using OnlyBooksApi.Core.Models;
using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.ViewModels;

namespace OnlyBooksApi.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public UsuarioViewModel Create(CreateOrUpdateUsuarioDto entity)
        {
            Usuario usuario = _mapper.Map<Usuario>(entity);

            _repository.Add(usuario);

            return _mapper.Map<UsuarioViewModel>(usuario);
        }

        public void Delete(int id)
        {
            Usuario usuario = _repository.GetById(id);

            if (usuario != null)
            {
                _repository.Delete(usuario);
                return;
            }

            throw new NotFoundException("Usuário não encontrado");
        }

        public List<UsuarioViewModel> GetAll()
        {
            IEnumerable<Usuario> usuarios = _repository.GetAll();

            List<UsuarioViewModel> usuariosDtos = _mapper.Map<List<UsuarioViewModel>>(usuarios);

            return usuariosDtos;
        }

        public UsuarioViewModel GetById(int id)
        {
            Usuario usuario = _repository.GetById(id);

            if (usuario != null)
            {
                return _mapper.Map<UsuarioViewModel>(usuario);
            }

            throw new NotFoundException("Usuário não encontrado");
        }

        public UsuarioViewModel Update(int id, CreateOrUpdateUsuarioDto dto)
        {
            Usuario usuarioExistente = _repository.GetById(id);

            if (usuarioExistente != null)
            {
                _mapper.Map(dto, usuarioExistente);

                _repository.Update(usuarioExistente);

                return _mapper.Map<UsuarioViewModel>(usuarioExistente);
            }

            throw new NotFoundException("Usuário não encontrado");
        }
    }
}
