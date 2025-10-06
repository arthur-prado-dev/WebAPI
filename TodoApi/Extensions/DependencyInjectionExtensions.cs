using TodoApi.Interfaces;
using TodoApi.Services;

namespace TodoApi.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection ConfigureDI(this IServiceCollection services)
    {
        services.AddScoped<ITodoService, TodoService>();
        
        return services;
    }
}