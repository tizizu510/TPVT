using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Infrastructure.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> ObtenerClimaActualAsync(double latitud, double longitud)
        {
            string url = $"https://api.open-meteo.com/v1/forecast?latitude={latitud}&longitude={longitud}&current_weather=true";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            var data = JObject.Parse(json);
            var temperatura = data["current_weather"]?["temperature"]?.ToString();

            return $"Temperatura actual: {temperatura}°C";
        }
    }
}