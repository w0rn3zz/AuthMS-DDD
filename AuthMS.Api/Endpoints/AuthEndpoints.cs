using AuthMS.Application.Commands;
using MediatR;

namespace AuthMS.Api.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/auth")
        .WithTags("Auth");
        
        group.MapPost("/register", async (RegisterUserCommand command, IMediator mediator) =>
        {
            var result = await mediator.Send(command);
            return Results.Created($"/api/users/{result.UserId}", result);
        });
    }
}
    