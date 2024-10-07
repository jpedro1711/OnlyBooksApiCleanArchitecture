using Microsoft.EntityFrameworkCore;
using OnlyBooksApi.Application.Interfaces.Repositories;
using OnlyBooksApi.Core.Models;
using OnlyBooksApi.Infrastructure.Data;

namespace OnlyBooksApi.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly OnlyBooksDbContext _context;
        public UsuarioRepository(OnlyBooksDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Delete(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios;
        }

        public Usuario GetById(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public Usuario GetAsNoTracking(int id)
        {
            return _context.Usuarios.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public List<Usuario> GetList()
        {
            return _context.Usuarios.ToList();
        }

        public void Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

    }
}
