﻿using MediatR;

namespace BibliotecaBasis.Comum.Mediator.Mensagens
{
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}