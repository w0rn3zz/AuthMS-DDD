using AuthMS.Domain.Exceptions;

namespace AuthMS.Domain.ValueObjects;

public sealed class Login : IEquatable<Login>
{
    public string Value { get; }

    private Login(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidLoginException("Login cannot be empty.");
        
        Value = value;
    }

    public static Login Create(string token)
    {
        return new Login(token);
    }

    public bool Equals(Login? other) => other?.Value == Value;
    public override bool Equals(object? obj) => obj is Login hash && Equals(hash);
    public override int GetHashCode() => Value.GetHashCode();
    public static bool operator ==(Login? left, Login? right) => 
        left?.Equals(right) ?? right is null;
    public static bool operator !=(Login? left, Login? right) => !(left == right);
    public override string ToString() => Value;
    
    public static implicit operator string(Login hash) => hash.Value;
}