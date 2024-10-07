﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlyBooksApi.Infrastructure.Data;

#nullable disable

namespace OnlyBooksApi.Migrations
{
    [DbContext(typeof(OnlyBooksDbContext))]
    [Migration("20240827220712_Remove")]
    partial class Remove
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlyBooksApi.Models.Emprestimo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataDevolucao")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReservaId")
                        .HasColumnType("int");

                    b.Property<int>("StatusEmprestimo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservaId");

                    b.ToTable("Emprestimos");
                });

            modelBuilder.Entity("OnlyBooksApi.Models.GeneroLivro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("OnlyBooksApi.Models.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GeneroLivroId")
                        .HasColumnType("int");

                    b.Property<double>("NotaAvaliacao")
                        .HasColumnType("float");

                    b.Property<int?>("ReservaId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("totalAvaliações")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GeneroLivroId");

                    b.HasIndex("ReservaId");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("OnlyBooksApi.Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataReserva")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusReserva")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("OnlyBooksApi.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("OnlyBooksApi.Models.Emprestimo", b =>
                {
                    b.HasOne("OnlyBooksApi.Models.Reserva", "Reserva")
                        .WithMany()
                        .HasForeignKey("ReservaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("OnlyBooksApi.Models.Livro", b =>
                {
                    b.HasOne("OnlyBooksApi.Models.GeneroLivro", "Genero")
                        .WithMany()
                        .HasForeignKey("GeneroLivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlyBooksApi.Models.Reserva", null)
                        .WithMany("Livros")
                        .HasForeignKey("ReservaId");

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("OnlyBooksApi.Models.Reserva", b =>
                {
                    b.HasOne("OnlyBooksApi.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("OnlyBooksApi.Models.Reserva", b =>
                {
                    b.Navigation("Livros");
                });
#pragma warning restore 612, 618
        }
    }
}
