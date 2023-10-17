using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private static List<WeatherForecast> ListWeatherForescast = new List<WeatherForecast>();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;

            if (ListWeatherForescast == null || !ListWeatherForescast.Any())
            {
                ListWeatherForescast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
           .ToList();
            }
        }

        [HttpGet(Name = "GetWeatherForecast")]
        //[Route("Get/weatherForescast", Name = "weatherForescast")]
        //[Route("/Get2/weatherForescast")]
        //[Route("[action]")]
        public IEnumerable<WeatherForecast> Get()
        {
            return ListWeatherForescast;
        }

        //[HttpGet]
        //[Route("Get3/weatherforescast")]
        //public IEnumerable<WeatherForecast> Get2D()
        //{
        //    return ListWeatherForescast;
        //}

        [HttpPost(Name = "PostWeatherForescast")]
        public ActionResult Post(WeatherForecast weather)
        {
            ListWeatherForescast.Add(weather);
            return Ok();
        }

        [HttpDelete("{index}", Name = "DeleteWeatherForescast")]
        public ActionResult Delete(int index)
        {
            ListWeatherForescast.RemoveAt(index);
            return Ok();
        }
    }
}