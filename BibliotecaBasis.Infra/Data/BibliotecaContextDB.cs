﻿using BibliotecaBasis.Comum.Mediator;
using BibliotecaBasis.Comum.Mediator.Mensagens;
using BibliotecaBasis.Comum.ObjetosDeInfra;
using BibliotecaBasis.Dominio.Entidades;
using BibliotecaBasis.Dominio.Models.Livros;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaBasis.Infra.Data
{
    public class BibliotecaContextDB : ContextBase, IUnitOfWorks
    {
        public DbSet<Livro>? Livros { get; set; }
        public DbSet<Assunto>? Assuntos { get; set; }
        public DbSet<Autor>? Autores { get; set; }
        public DbSet<Preco>? Precos { get; set; }

        public DbSet<LivroViewModel>? LivrosCompletosViewModel { get; set; }

        
        public BibliotecaContextDB(DbContextOptions<BibliotecaContextDB> options,
                  IMediatorHandler mediatorHandler)
            : base(options, mediatorHandler)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BibliotecaContextDB).Assembly);
        }

    }
}
