using TodoApi.Interfaces;
using TodoApi.Models;
using TodoApi.Models.ResultPattern;

namespace TodoApi.Services;

public class TodoService (List<Todo> todoList): ITodoService
{
    private static readonly object _lock = new();
        
    public ServiceResult<List<Todo>> GetAll()
    {
        return todoList.Count != 0
            ? ServiceResult<List<Todo>>.Ok(todoList, "Itens carregados com sucesso.")
            : ServiceResult<List<Todo>>.Fail("Não há itens a serem carregados.");
    }
}