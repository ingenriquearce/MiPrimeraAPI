using Microsoft.AspNetCore.Mvc;
namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    //Here service is storaged in a variable, I'm bringing me interface
    IHelloWorldService helloWorldService;

    //Here, I put constructor. Note.- Constructor have the same name that class
    public HelloWorldController(IHelloWorldService helloWorld)
    {
        helloWorldService = helloWorld;
    }

    //Aqui tengo el pendiente de probar este controlador en postman y luego recien hacer el logging que estoy creando
    //private static readonly ILogger<HelloWorldController> _logger;

    [HttpGet]
    public IActionResult Get()
    {
        //_logger.LogInformation("El hello world se esta ejecutando...");
        return Ok(helloWorldService.GetHelloWorld());
    }
}