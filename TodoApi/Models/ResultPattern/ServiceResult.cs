namespace TodoApi.Models.ResultPattern;

public class ServiceResult<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }
    
    private ServiceResult(bool success, string message, T? data = default)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public static ServiceResult<T> Ok(T data, string message)
        => new(true, message, data);

    public static ServiceResult<T> Fail(string message)
        => new(false, message);
}