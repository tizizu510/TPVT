using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public static class EventoExceptions
    {
        public class EventoNoEncontradoException : BaseException
        {
            public EventoNoEncontradoException(int eventoId)
                : base($"Evento con id {eventoId} no fue encontrado.", "EVENT_NOT_FOUND", 404)
            {
            }
        }

        public class EventoNoDisponibleException : BaseException
        {
            public EventoNoDisponibleException(int eventoId)
                : base($"El evento {eventoId} no está disponible", "EVENT_NOT_AVAILABLE", 400)
            {
            }
        }
    }
}
