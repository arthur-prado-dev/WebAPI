using TodoApi.Models;
using TodoApi.Models.ResultPattern;
using TodoApi.Services;

namespace TodoApi.Interfaces;

public interface ITodoService
{
    ServiceResult<List<Todo>> GetAll();
}