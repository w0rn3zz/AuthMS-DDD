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
            throw new ArgumentException("Name cannot be empty.", nameof(name));
        if (string.IsNullOrWhiteSpace(login))
            throw new ArgumentException("Login cannot be empty.", nameof(login));
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("Password cannot be empty.", nameof(passwordHash));

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
            throw new ArgumentException("Password cannot be empty.", nameof(newPasswordHash));
        }

        PasswordHash = PasswordHash.FromHash(newPasswordHash);
    }
}