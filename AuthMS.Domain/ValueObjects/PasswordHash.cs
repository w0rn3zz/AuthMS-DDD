using AuthMS.Domain.Exceptions;

namespace AuthMS.Domain.ValueObjects;

public sealed class PasswordHash : IEquatable<PasswordHash>
{
    public string Value { get; }

    private PasswordHash(string hashedValue)
    {
        if (string.IsNullOrWhiteSpace(hashedValue))
            throw new InvalidPasswordHashException("Password hash cannot be empty.");
        
        Value = hashedValue;
    }

    public static PasswordHash FromHash(string hash)
    {
        return new PasswordHash(hash);
    }

    public bool Equals(PasswordHash? other) => other?.Value == Value;
    public override bool Equals(object? obj) => obj is PasswordHash hash && Equals(hash);
    public override int GetHashCode() => Value.GetHashCode();
    public static bool operator ==(PasswordHash? left, PasswordHash? right) => 
        left?.Equals(right) ?? right is null;
    public static bool operator !=(PasswordHash? left, PasswordHash? right) => !(left == right);
    public override string ToString() => Value;
    
    public static implicit operator string(PasswordHash hash) => hash.Value;
}