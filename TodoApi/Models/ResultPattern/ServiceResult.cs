namespace TodoApi.Models.ResultPattern;

public class ServiceResult
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    
    protected ServiceResult(bool success, string? message = null)
    {
        Success = success;
        Message = message;
    }
    
    public static ServiceResult Ok() => new(true);
    public static ServiceResult Fail(string message) => new(false, message);
}

public class ServiceResult<T> : ServiceResult
{
    public T? Data { get; set; }
    
    private ServiceResult(bool success, string message, T? data = default)
     : base(success, message)
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