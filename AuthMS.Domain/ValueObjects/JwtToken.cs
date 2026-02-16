

namespace AuthMS.Domain.ValueObjects;

public sealed class JwtToken : IEquatable<JwtToken>
{
    public string Value { get; }

    private JwtToken(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("JwtToken cannot be empty");
        
        Value = value;
    }

    public static JwtToken Create(string token)
    {
        return new JwtToken(token);
    }

    public bool Equals(JwtToken? other) => other?.Value == Value;
    public override bool Equals(object? obj) => obj is JwtToken hash && Equals(hash);
    public override int GetHashCode() => Value.GetHashCode();
    public static bool operator ==(JwtToken? left, JwtToken? right) => 
        left?.Equals(right) ?? right is null;
    public static bool operator !=(JwtToken? left, JwtToken? right) => !(left == right);
    public override string ToString() => Value;
    
    public static implicit operator string(JwtToken hash) => hash.Value;
}