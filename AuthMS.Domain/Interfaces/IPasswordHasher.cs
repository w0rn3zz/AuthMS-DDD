using AuthMS.Domain.ValueObjects;

namespace AuthMS.Domain.Interfaces;

public interface IPasswordHasher
{
    PasswordHash HashPassword(string password);
    bool VerifyPassword(string password, PasswordHash passwordHash);
}