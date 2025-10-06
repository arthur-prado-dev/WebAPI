namespace TodoApi.Models.Responses;

public record TodoResponse(int Id, string Title, bool Done)
{
    public static TodoResponse FromEntity(Todo entity)
        => new(entity.Id, entity.Title!, (bool)entity.Done!);

    public static List<TodoResponse> EntityList(List<Todo> entityList)
    {
        var result = entityList
            .Select(e => new TodoResponse(e.Id, e.Title!, (bool)e.Done!));

        return result.ToList();
    }
}