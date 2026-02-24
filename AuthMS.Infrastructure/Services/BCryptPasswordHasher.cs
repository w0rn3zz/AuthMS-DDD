using AuthMS.Domain.Interfaces;
using AuthMS.Domain.ValueObjects;

namespace AuthMS.Infrastructure.Services;

public class BCryptPasswordHasher : IPasswordHasher
{
    public PasswordHash HashPassword(string password)
    {
        var hash = BCrypt.Net.BCrypt.HashPassword(password);
        return PasswordHash.FromHash(hash);
    }

    public bool VerifyPassword(string password, PasswordHash passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash.Value);
    }
}