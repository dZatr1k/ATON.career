using Aton.Career.UserService.Exceptions;
using System.Text.Json;

namespace Aton.Career.UserService.Middlewares;
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (UserException e)
        {
            context.Response.StatusCode = e.StatusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                error = e.Message
            }));
        }
    }
}

