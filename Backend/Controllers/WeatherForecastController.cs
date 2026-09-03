using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        
        //creamos un endpoint que devuelva el hola mundo
        [HttpGet("holamundo")]
        public string GetHolaMundo()
        {
            return "Hola mundo, desde San Justo";
        }

        public class Mensaje()
        {
            public string texto { get; set; }
            public DateTime fechaHoraConsulta { get; set; }
        }

        [HttpGet("getmensaje")]
        public Mensaje GetMensaje()
        {
            return new Mensaje() { 
                texto="Estamos probando crear nuestras apis",
                fechaHoraConsulta=DateTime.Now
            };
        }
    }
}
