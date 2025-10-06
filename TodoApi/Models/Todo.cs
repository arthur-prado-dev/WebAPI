using TodoApi.Models.Requests;

namespace TodoApi.Models;

public class Todo
{
    private static int _id = 1;
    
    public int Id { get; }
    public string? Title { get; private set; }
    public bool? Done { get; private set; }

    public Todo(string title, bool done)
    {
        Id = _id;
        Title = title;
        Done = done;

        _id++;
    }

    public bool IsValid()
    {
        return Id > 0 && Title is not null && Done is not null;
    }

    public bool IsNotValid()
    {
        return !IsValid();
    }

    public Todo TryUpdate(TodoRequest request)
    {
        Title = request.Title;
        Done = request.Done;

        return this;
    }
}