using Microsoft.EntityFrameworkCore;
using OnlyBooksApi.Application.Interfaces.Repositories;
using OnlyBooksApi.Core.Models;
using OnlyBooksApi.Infrastructure.Data;

namespace OnlyBooksApi.Infrastructure.Repositories
{
    public class GeneroLivroRepository : IGeneroLivroRepository
    {
        private readonly OnlyBooksDbContext _context;
        public GeneroLivroRepository(OnlyBooksDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add(GeneroLivro genero)
        {
            _context.Generos.Add(genero);
            _context.SaveChanges();
        }

        public void Delete(GeneroLivro genero)
        {
            _context.Generos.Remove(genero);
            _context.SaveChanges();
        }

        public IEnumerable<GeneroLivro> GetAll()
        {
            return _context.Generos;
        }

        public GeneroLivro GetById(int id)
        {
            return _context.Generos.FirstOrDefault(x => x.Id == id);
        }

        public GeneroLivro GetAsNoTracking(int id)
        {
            return _context.Generos.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public List<GeneroLivro> GetList()
        {
            return _context.Generos.ToList();
        }

        public void Update(GeneroLivro genero)
        {
            _context.Generos.Update(genero);
            _context.SaveChanges();
        }
    }
}
