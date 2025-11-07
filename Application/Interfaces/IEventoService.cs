using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IEventoService
    {
        List<EventoDTO> ObtenerEventos();
        EventoDTO? ObtenerPorId(int id);
        void AgregarEvento(EventoDTO dto);
        void ModificarEvento(EventoDTO dto);
        void EliminarEvento(int id);
    }
}