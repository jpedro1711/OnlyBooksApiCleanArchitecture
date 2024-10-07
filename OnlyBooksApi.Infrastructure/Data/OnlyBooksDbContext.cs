using Microsoft.EntityFrameworkCore;
using OnlyBooksApi.Core.Models;

namespace OnlyBooksApi.Infrastructure.Data
{
    public class OnlyBooksDbContext : DbContext
    {
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<GeneroLivro> Generos { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        public OnlyBooksDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                    .HasIndex(u => u.Email)
                    .IsUnique(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
