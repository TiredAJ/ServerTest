using Microsoft.AspNetCore.Mvc;

namespace ServerTest.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
        ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

    private readonly ILogger<WeatherForecastController> _Logger;

    public WeatherForecastController(ILogger<WeatherForecastController> _Logger)
    {
        this._Logger = _Logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(_Index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(_Index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}