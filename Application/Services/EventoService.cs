using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public List<EventoDTO> ObtenerEventos()
        {
            return _eventoRepository.GetAll()
                .Select(e => new EventoDTO
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Descripcion = e.Descripcion,
                    Fecha = e.Fecha,
                    Lugar = e.Lugar,
                    Precio = e.Precio,
                    Disponible = e.Disponible
                }).ToList();
        }

        public EventoDTO? ObtenerPorId(int id)
        {
            var evento = _eventoRepository.GetById(id);
            if (evento == null)
                throw new EventoExceptions.EventoNoEncontradoException(id);

            return new EventoDTO
            {
                Id = evento.Id,
                Nombre = evento.Nombre,
                Descripcion = evento.Descripcion,
                Fecha = evento.Fecha,
                Lugar = evento.Lugar,
                Precio = evento.Precio,
                Disponible = evento.Disponible
            };
        }

        public void AgregarEvento(EventoDTO dto)
        {
            _eventoRepository.Add(new Evento
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Fecha = dto.Fecha,
                Lugar = dto.Lugar,
                Precio = dto.Precio,
                Disponible = dto.Disponible
            });
        }

        public void ModificarEvento(EventoDTO dto)
        {
            var eventoExistente = _eventoRepository.GetById(dto.Id);
            if (eventoExistente == null)
                //throw new System.Exception("Evento no encontrado");
                throw new EventoExceptions.EventoNoEncontradoException(dto.Id);

            eventoExistente.Nombre = dto.Nombre;
            eventoExistente.Descripcion = dto.Descripcion;
            eventoExistente.Fecha = dto.Fecha;
            eventoExistente.Lugar = dto.Lugar;
            eventoExistente.Precio = dto.Precio;
            eventoExistente.Disponible = dto.Disponible;

            _eventoRepository.Update(eventoExistente);
        }
        public void EliminarEvento(int id)
        {
            var eventoExistente = _eventoRepository.GetById(id);
            if (eventoExistente == null)
                //throw new System.Exception("Evento no encontrado");
                throw new EventoExceptions.EventoNoEncontradoException(id);

            _eventoRepository.Delete(id);
        }
    }
}