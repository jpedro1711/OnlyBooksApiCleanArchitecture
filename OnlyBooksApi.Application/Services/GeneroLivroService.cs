using AutoMapper;
using OnlyBooksApi.Application.Interfaces.Repositories;
using OnlyBooksApi.Application.Interfaces.Services;
using OnlyBooksApi.Core.Exceptions;
using OnlyBooksApi.Core.Models;
using OnlyBooksApi.Core.Models.Dtos;
using OnlyBooksApi.Core.Models.ViewModels;

namespace OnlyBooksApi.Application.Services
{
    public class GeneroLivroService : IGeneroLivroService
    {
        private readonly IGeneroLivroRepository _repository;
        private readonly IMapper _mapper;
        public GeneroLivroService(IGeneroLivroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public GeneroLivroViewModel Create(GeneroLivroDto entity)
        {
            GeneroLivro genero = _mapper.Map<GeneroLivro>(entity);

            _repository.Add(genero);

            return _mapper.Map<GeneroLivroViewModel>(genero);
        }

        public void Delete(int id)
        {
            GeneroLivro livro = _repository.GetById(id);

            if (livro != null)
            {
                _repository.Delete(livro);
                return;
            }

            throw new NotFoundException("Genêro livro não encontrado");
        }

        public List<GeneroLivroViewModel> GetAll()
        {
            IEnumerable<GeneroLivro> generos = _repository.GetAll();

            List<GeneroLivroViewModel> generoDtos = _mapper.Map<List<GeneroLivroViewModel>>(generos);

            return generoDtos;
        }

        public GeneroLivroViewModel GetById(int id)
        {
            GeneroLivro genero = _repository.GetById(id);

            if (genero != null)
            {
                return _mapper.Map<GeneroLivroViewModel>(genero);
            }

            throw new NotFoundException("Genêro livro não encontrado");
        }

        public GeneroLivroViewModel Update(int id, GeneroLivroDto dto)
        {
            GeneroLivro generoExistente = _repository.GetById(id);

            if (generoExistente != null)
            {
                generoExistente.Nome = dto.Nome;

                _repository.Update(generoExistente);

                return _mapper.Map<GeneroLivroViewModel>(generoExistente);
            }

            throw new NotFoundException("Genêro livro não encontrado");
        }

    }
}
