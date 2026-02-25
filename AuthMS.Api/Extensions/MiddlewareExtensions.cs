using AuthMS.Api.Middleware;

namespace AuthMS.Api.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseCustomExceptionsHandler(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionMiddleware>();
    }
}