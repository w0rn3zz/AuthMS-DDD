using MediatR;
using AuthMS.Application.DTOs;
using AuthMS.Domain.Interfaces;
using AuthMS.Domain.Exceptions;
using AuthMS.Domain.Entities;

namespace AuthMS.Application.Commands;

public class RegisterUserCommandHandler
    : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }



    public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken ct )
    {
        var existingUser = await _userRepository.GetByLoginAsync(request.Login, ct);

        if (existingUser is not null)
        {
            throw new UserAlreadyExistsException(request.Login);
        }

        var passwordHash = _passwordHasher.HashPassword(request.Password);
        var user = UserEntity.Create(request.Name, request.Login, passwordHash.Value);

        await _userRepository.AddAsync(user, ct);

        return new RegisterUserResponse(
            user.Id.Value,
            user.Login.Value,
            user.CreatedAt
        );
    }
}