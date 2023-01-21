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
        helloWorld = helloWorldService;    
    }

    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }
}