namespace AuthMS.Application.DTOs;

public record RegisterUserResponse(
    Guid UserId,
    string Login,
    DateTime CreatedAt
);