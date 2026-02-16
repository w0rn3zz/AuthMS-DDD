using AuthMS.Domain.Exceptions;

namespace AuthMS.Domain.ValueObjects;

public sealed class UserId : IEquatable<UserId>
{
    public Guid Value { get; }

    private UserId(Guid value)
    {
        if (value == Guid.Empty)
            throw new InvalidUserIdException("UserId cannot be empty.");
        
        Value = value;
    }

    public static UserId Create(Guid id)
    {
        return new UserId(id);
    }

    public static UserId NewId()
    {
        return new UserId(Guid.NewGuid());
    }

    public bool Equals(UserId? other) => other?.Value == Value;
    public override bool Equals(object? obj) => obj is UserId hash && Equals(hash);
    public override int GetHashCode() => Value.GetHashCode();
    public static bool operator ==(UserId? left, UserId? right) => 
        left?.Equals(right) ?? right is null;
    public static bool operator !=(UserId? left, UserId? right) => !(left == right);
    public override string ToString() => Value.ToString();
    
    public static implicit operator Guid(UserId id) => id.Value;
}