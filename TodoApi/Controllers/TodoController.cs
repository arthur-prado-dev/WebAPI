using Microsoft.AspNetCore.Mvc;
using TodoApi.Interfaces;
using TodoApi.Models.Requests;
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

    [HttpGet]
    [Route("GetById/{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var result = service.GetById(id);

        return result.Success
            ? Ok(TodoResponse.FromEntity(result.Data!))
            : NotFound(result.Message);
    }

    [HttpPost]
    [Route("Create")]
    public IActionResult Create([FromBody] TodoRequest request)
    {
        var result = service.Create(request);

        return result.Success
            ? CreatedAtAction(nameof(GetById), new { Id = result.Data!.Id }, result.Data)
            : BadRequest("Ocorreu um erro ao criar sua tarefa, tente novamente.");
    }

    [HttpPatch]
    [Route("Update/{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] TodoRequest request)
    {
        var result = service.Update(id, request);

        return result.Success
            ? Ok(TodoResponse.FromEntity(result.Data!))
            : BadRequest(result.Message);
    }
}