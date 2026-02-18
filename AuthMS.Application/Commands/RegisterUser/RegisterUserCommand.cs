using MediatR;
using AuthMS.Application.DTOs;

namespace AuthMS.Application.Commands;

public record RegisterUserCommand(
    string Name,
    string Login,
    string Password
) : IRequest<RegisterUserResponse>;


