﻿using BibliotecaBasis.Aplicacao.Comandos.Livros.Validacao;
using BibliotecaBasis.Dominio.Models.Precos;

namespace BibliotecaBasis.Aplicacao.Comandos.Livros.Commands
{
    public class AdicionarPrecoCommand : PrecoCommand
    {
        public AdicionarPrecoCommand(AdicionaPrecoRequestModel model)
        {
            LivroId = model.LivroId;
            Valor = model.Valor;
            FormaDeVenda = model.FormaDeVenda;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarPrecoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarPrecoCommandValidation : PrecoValidation<AdicionarPrecoCommand>
        {
            public AdicionarPrecoCommandValidation()
            {
                ValidateLivroId();
                ValidateValor();
                ValidateFormaDeVenda();
            }
        }
    }
}
