using TodoApi.Models;
using TodoApi.Models.Requests;
using TodoApi.Models.ResultPattern;
using TodoApi.Services;

namespace TodoApi.Interfaces;

public interface ITodoService
{
    ServiceResult<List<Todo>> GetAll();
    ServiceResult<Todo> GetById(int id);
    ServiceResult<Todo> Create(TodoRequest request);
}