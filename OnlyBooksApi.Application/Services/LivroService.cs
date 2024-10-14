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
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _repository;
        private readonly IGeneroLivroService _generoLivroService;
        private readonly IMapper _mapper;
        public LivroService(ILivroRepository repository, IGeneroLivroService generoLivroService, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _generoLivroService = generoLivroService;
        }

        public LivroViewModel Create(CreateLivroDto entity)
        {
            Livro livro = _mapper.Map<Livro>(entity);

            GeneroLivroViewModel genero = _generoLivroService.GetById(entity.GeneroLivroId);

            livro.GeneroLivroId = genero.Id;

            _repository.Add(livro);

            return _mapper.Map<LivroViewModel>(livro);
        }

        public void Delete(int id)
        {
            Livro livro = _repository.GetById(id);

            if (livro != null)
            {
                _repository.Delete(livro);
                return;
            }

            throw new NotFoundException("Livro não encontrado");
        }

        public List<LivroViewModel> GetAll()
        {
            IEnumerable<Livro> livros = _repository.GetAll();

            List<LivroViewModel> livrosDtos = _mapper.Map<List<LivroViewModel>>(livros);

            return livrosDtos;
        }

        public LivroViewModel GetById(int id)
        {
            Livro livro = _repository.GetById(id);

            if (livro != null)
            {
                return _mapper.Map<LivroViewModel>(livro);
            }

            throw new NotFoundException("Livro não encontrado");
        }

        public LivroViewModel Update(int id, Livro dto)
        {
            Livro livroExistente = _repository.GetById(id);

            if (livroExistente != null)
            {
                _mapper.Map(dto, livroExistente);

                _repository.Update(livroExistente);

                return _mapper.Map<LivroViewModel>(livroExistente);
            }

            throw new NotFoundException("Livro não encontrado");
        }

        public LivroViewModel AtualizarStatus(int id, StatusLivro novoStatus)
        {
            Livro livroExistente = _repository.GetById(id);

            if (livroExistente != null)
            {
                livroExistente.Status = novoStatus;
                _repository.Update(livroExistente);

                return _mapper.Map<LivroViewModel>(livroExistente);
            }

            throw new NotFoundException("Livro não encontrado");
        }

        public LivroViewModel AvaliarLivro(int id, int novaNota)
        {
            Livro livro = _repository.GetById(id);

            if (livro != null)
            {
                var totalAvaliacoes = livro.TotalAvaliações;
                int somaTotalAvaliacoes = livro.SomaTotalAvaliaçoes ?? 1;

                totalAvaliacoes += 1;
                somaTotalAvaliacoes += novaNota;

                double novaMediaAvaliacao = somaTotalAvaliacoes / (double)(totalAvaliacoes ?? 1);

                livro.NotaAvaliacao = novaMediaAvaliacao;
                livro.TotalAvaliações = totalAvaliacoes;
                livro.SomaTotalAvaliaçoes = somaTotalAvaliacoes;

                _repository.Update(livro);

                return _mapper.Map<LivroViewModel>(livro);

            }

            throw new NotFoundException("Livro não encontrado");
        }
    }
}
