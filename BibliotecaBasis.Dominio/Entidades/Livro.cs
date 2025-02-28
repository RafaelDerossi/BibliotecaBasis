﻿using BibliotecaBasis.Comum.ObjetosDeDominio;

namespace BibliotecaBasis.Dominio.Entidades
{
    public class Livro(string? titulo, string? editora, int edicao, string? anoPublicacao) : Entidade, IAggregateRoot
    {
        public const int TituloSize = 40, EditoraSize = 40, AnoPublicacaoSize = 4;

        public string? Titulo { get; private set; } = titulo;

        public string? Editora { get; private set; } = editora;

        public int Edicao { get; private set; } = edicao;

        public string? AnoPublicacao { get; private set; } = anoPublicacao;


        private readonly List<Autor> _Autores = [];
        public IReadOnlyCollection<Autor>? Autores => _Autores;


        private readonly List<Assunto> _Assuntos = [];
        public IReadOnlyCollection<Assunto>? Assuntos => _Assuntos;


        private readonly List<Preco> _Precos = [];
        public IReadOnlyCollection<Preco>? Precos => _Precos.Where(p=>!p.Lixeira).ToList();



        public void SetTitulo(string? valor) => Titulo = valor;

        public void SetEditora(string? valor) => Editora = valor;

        public void SetEdicao(int valor) => Edicao = valor;

        public void SetAnoPublicacao(string? valor) => AnoPublicacao = valor;

        
        public void SetAssuntos(IEnumerable<Assunto> assuntos) => _Assuntos.AddRange(assuntos.ToList());

        public void ApagarAssuntos() => _Assuntos.Clear();


        public void SetAutores(IEnumerable<Autor> autores) => _Autores.AddRange(autores.ToList());

        public void ApagarAutores() => _Autores.Clear();

    }
}
