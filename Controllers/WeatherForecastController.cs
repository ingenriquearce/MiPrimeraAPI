using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();

    //This is the constructor method
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        //We can need that data enter through this method so that this data live on memory
        if(ListWeatherForecast == null || !ListWeatherForecast.Any())
        {
            ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [Route("GetWeatherForecast")]
    [Route("GetWeatherForecast2")]
    [Route("[action]")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation("La lista esta retornando los weathers");
        //As this method only needs to show data, only we return the list
        return ListWeatherForecast;
    }

    [HttpPost(Name = "PostWeatherForecast")]
    [Route("PostWeatherForecast")]
    [Route("PostWeatherForecast2")]
    [Route("[action]")] //This route is dynamic because it point to the action (specific method)
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListWeatherForecast.Add(weatherForecast);
        return Ok();
    }

    [HttpDelete("{index}", Name = "DeleteWeatherForecast")]
    [Route("DeleteWeatherForecast")]
    [Route("DeleteWeatherForecast2")]
    [Route("[action]")]
    public IActionResult Delete(int index)
    {
        ListWeatherForecast.RemoveAt(index);
        return Ok();
    }
}