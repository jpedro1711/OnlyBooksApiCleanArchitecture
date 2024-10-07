using AutoMapper;
using OnlyBooksApi.Application.Interfaces.Repositories;
using OnlyBooksApi.Application.Interfaces.Services;
using OnlyBooksApi.Core.Exceptions;
using OnlyBooksApi.Core.Models;
using OnlyBooksApi.Core.Models.Dtos;

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

        public GeneroLivroResponseDto Create(GeneroLivroDto entity)
        {
            GeneroLivro genero = _mapper.Map<GeneroLivro>(entity);

            _repository.Add(genero);

            return _mapper.Map<GeneroLivroResponseDto>(genero);
        }

        public void Delete(int id)
        {
            GeneroLivro livro = _repository.GetById(id);

            if (livro != null)
            {
                _repository.Delete(livro);
                return;
            }

            throw new GeneroLivroException("Genêro livro não encontrado");
        }

        public List<GeneroLivroResponseDto> GetAll()
        {
            IEnumerable<GeneroLivro> generos = _repository.GetAll();

            List<GeneroLivroResponseDto> generoDtos = _mapper.Map<List<GeneroLivroResponseDto>>(generos);

            return generoDtos;
        }

        public GeneroLivroResponseDto GetById(int id)
        {
            GeneroLivro genero = _repository.GetById(id);

            if (genero != null)
            {
                return _mapper.Map<GeneroLivroResponseDto>(genero);
            }

            throw new GeneroLivroException("Genêro livro não encontrado");
        }

        public GeneroLivroResponseDto Update(int id, GeneroLivroDto dto)
        {
            GeneroLivro generoExistente = _repository.GetById(id);

            if (generoExistente != null)
            {
                generoExistente.Nome = dto.Nome;

                _repository.Update(generoExistente);

                return _mapper.Map<GeneroLivroResponseDto>(generoExistente);
            }

            throw new GeneroLivroException("Genêro livro não encontrado");
        }

    }
}
