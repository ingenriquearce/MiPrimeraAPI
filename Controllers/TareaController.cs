using Microsoft.AspNetCore.Mvc;
using webapi.Models;

public class TareaController : ControllerBase
{
    ITareaService tareaService;
    public TareaController(TareaService service)
    {
        tareaService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        tareaService.Save(tarea);
        return Ok();
    }

    [HttpPut]
    public IActionResult Put(Guid id, [FromBody] Tarea tarea)
    {
        tareaService.Update(id, tarea);
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        tareaService.Delete(id);
        return Ok();
    }
}