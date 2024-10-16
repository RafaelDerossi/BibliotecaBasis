﻿using BibliotecaBasis.Aplicacao.Comandos.Livros.Validacao;
using BibliotecaBasis.Dominio.ViewModels;

namespace BibliotecaBasis.Aplicacao.Comandos.Livros.Commands
{
    public class AdicionarLivroCommand : LivroCommand
    {
        public AdicionarLivroCommand(LivroViewModel model)
        {
            Titulo = model.Titulo;
            Editora = model.Editora;
            Edicao = model.Edicao;
            AnoPublicacao = model.AnoPublicacao;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarLivroCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarLivroCommandValidation : LivroValidation<AdicionarLivroCommand>
        {
            public AdicionarLivroCommandValidation()
            {
                ValidateTitulo();
                ValidateEditora();
                ValidateAnoPublicacao();
            }
        }
    }
}
