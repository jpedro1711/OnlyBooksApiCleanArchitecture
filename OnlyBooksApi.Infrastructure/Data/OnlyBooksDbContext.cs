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

            modelBuilder.Entity<ReservaLivro>()
                    .HasKey(bc => new { bc.ReservaId, bc.LivroId });

            modelBuilder.Entity<ReservaLivro>()
                    .HasOne(b => b.Livro)
                    .WithMany(bc => bc.ReservaLivros)
                    .HasForeignKey(bc => bc.ReservaId);

            modelBuilder.Entity<ReservaLivro>()
                    .HasOne(b => b.Livro)
                    .WithMany(bc => bc.ReservaLivros)
                    .HasForeignKey(bc => bc.LivroId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
