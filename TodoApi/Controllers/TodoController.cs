using Microsoft.AspNetCore.Mvc;
using TodoApi.Interfaces;
using TodoApi.Models.Responses;

namespace TodoApi.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class TodoController(ITodoService service) : ControllerBase
{
    [HttpGet]
    [Route("GetAll")]
    public IActionResult GetAll()
    {
        var result = service.GetAll();

        return result.Success
            ? Ok(TodoResponse.EntityList(result.Data!))
            : NotFound(result.Message);
    }
}