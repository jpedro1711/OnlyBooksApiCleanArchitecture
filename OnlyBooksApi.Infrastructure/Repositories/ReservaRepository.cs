using Microsoft.EntityFrameworkCore;
using OnlyBooksApi.Application.Interfaces.Repositories;
using OnlyBooksApi.Core.Models;
using OnlyBooksApi.Infrastructure.Data;

namespace OnlyBooksApi.Infrastructure.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly OnlyBooksDbContext _context;
        public ReservaRepository(OnlyBooksDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            _context.SaveChanges();
        }

        public void Delete(Reserva reserva)
        {
            _context.Reservas.Remove(reserva);
            _context.SaveChanges();
        }

        public IEnumerable<Reserva> GetAll()
        {
            return _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.ReservaLivros)
                .ThenInclude(rl => rl.Livro)
                .ToList();
        }

        public IQueryable<Reserva> GetByuserEmail(string userEmail)
        {
            return _context.Reservas
                    .Include(r => r.Usuario)
                    .Include(r => r.ReservaLivros)
                    .ThenInclude(r => r.Livro)
                    .Where(r => r.Usuario.Email.ToLower().Equals(userEmail.ToLower()));
        }

        public Reserva GetById(int id)
        {
            return _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.ReservaLivros)
                .ThenInclude(rl => rl.Livro)
                .FirstOrDefault(x => x.Id == id);
        }

        public Reserva GetAsNoTracking(int id)
        {
            return _context.Reservas.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public List<Reserva> GetList()
        {
            return _context.Reservas.ToList();
        }

        public void Update(Reserva reserva)
        {
            _context.Reservas.Update(reserva);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
