using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using TodoApi.Interfaces;
using TodoApi.Models;
using TodoApi.Models.Requests;
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

    public ServiceResult<Todo> GetById(int id)
    {
        var todoById = todoList.FirstOrDefault(t => t.Id == id);

        return todoById is not null
            ? ServiceResult<Todo>.Ok(todoById, "Item encontrado com sucesso.")
            : ServiceResult<Todo>.Fail("Não há um item com esse id.");
    }

    public ServiceResult<Todo> Create(TodoRequest request)
    {
        lock (_lock)
        {
            var createdTodo = new Todo(request.Title, request.Done);
            todoList.Add(createdTodo);

            return ServiceResult<Todo>.Ok(createdTodo, "Item adicionado com sucesso.");
        }
    }

    public ServiceResult<Todo> Update(int id, TodoRequest request)
    {
        lock (_lock)
        {
            var todoToUpdate = todoList.FirstOrDefault(t => t.Id == id);

            todoToUpdate?.TryUpdate(request);

            return todoToUpdate is not null
                ? ServiceResult<Todo>.Ok(todoToUpdate, "Item Alterado com sucesso")
                : ServiceResult<Todo>.Fail("Não há item com este id para ser alterado");
        }
    }
}