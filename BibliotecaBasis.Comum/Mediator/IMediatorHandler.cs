﻿using FluentValidation.Results;
using BibliotecaBasis.Comum.Mensagens;

namespace BibliotecaBasis.Comum.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;

        Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
    }
}
