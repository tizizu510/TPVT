using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("CONSULTAR TEMPERATURA")]
        public async Task<IActionResult> GetCurrentWeather(double lat, double lon)
        {
            var clima = await _weatherService.ObtenerClimaActualAsync(lat, lon);
            return Ok(new { resultado = clima });
        }
    }
}