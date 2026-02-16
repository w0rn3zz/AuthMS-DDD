using AuthMS.Domain.Exceptions;
using AuthMS.Domain.ValueObjects;

namespace AuthMS.Domain.Entities;

public class UserEntity
{
    public UserId Id {get; private set;} = null!;
    public string Name {get; private set;} = null!;
    public Login Login {get; private set;} = null!;
    public PasswordHash PasswordHash {get; private set;} = null!;
    public DateTime CreatedAt {get; private set;}

    private UserEntity() {}

    private UserEntity(string name, string login, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ValidationException(nameof(Name), "Name cannot be empty.");
        if (string.IsNullOrWhiteSpace(login))
            throw new InvalidLoginException("Login cannot be empty.");
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new InvalidPasswordHashException("Password hash cannot be empty.");

        Id = UserId.NewId();
        Name = name;
        Login = Login.Create(login);
        PasswordHash = PasswordHash.FromHash(passwordHash);
        CreatedAt = DateTime.Now;
    }

    public static UserEntity Create(string name, string login, string passwordHash)
    {
        return new UserEntity(name, login, passwordHash);
    }

    public bool VerifyPassword(string password)
    {
        return PasswordHash.Value == password;
    }

    public void UpdatePassword(string newPasswordHash)
    {
        if (string.IsNullOrWhiteSpace(newPasswordHash))
        {
            throw new InvalidPasswordHashException("Password hash cannot be empty.");
        }

        PasswordHash = PasswordHash.FromHash(newPasswordHash);
    }
}