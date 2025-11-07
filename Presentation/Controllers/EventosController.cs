using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        // Si más adelante tenés IEventoService, lo inyectás aquí
        // private readonly IEventoService _eventoService;
        private readonly IEventoService _eventoService;

        // public EventoController()
        public EventoController(IEventoService eventoService)
        {
             _eventoService = eventoService;
        }

        //  Agregar evento (solo Admin/SuperAdmin)
        [HttpPost("AGREGAR EVENTO")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public IActionResult AgregarEvento([FromBody] EventoDTO eventoDto)

        {
            try
            {
                _eventoService.AgregarEvento(eventoDto);
                return Ok(new { message = "Evento agregado exitosamente." });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        //  Modificar evento (solo Admin/SuperAdmin)

        [HttpPut("MODIFICAR EVENTO POR ID")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public IActionResult ModificarEvento(int id, [FromBody] EventoDTO eventoDto)
        {
            try
            {
                if (id != eventoDto.Id)
                    return BadRequest("ID del evento no coincide");

                _eventoService.ModificarEvento(eventoDto);
                return Ok(new { message = $"Evento {id} modificado exitosamente." });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        //Eliminar evento (solo Admin/SuperAdmin)

        [HttpDelete("ELIMINAR EVENTO POR ID")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public IActionResult EliminarEvento(int id)
        {
            try
            {
                _eventoService.EliminarEvento(id);
                return Ok(new { message = $"Evento {id} eliminado exitosamente." });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }


        //  Listar todos los eventos (cualquiera)
        [HttpGet("todos")]
        [AllowAnonymous]
        public IActionResult ObtenerTodosLosEventos()
        {
            var eventos = _eventoService.ObtenerEventos();
            return Ok(eventos);
        }
    }

}