namespace AuthMS.Domain.Exceptions;

// ===== Login Value Object =====
public class InvalidLoginException : DomainException
{
    public string? AttemptedValue { get; }
    
    public InvalidLoginException(string message) 
        : base($"Invalid login: {message}")
    {
    }
    
    public InvalidLoginException(string message, string attemptedValue) 
        : base($"Invalid login: {message}")
    {
        AttemptedValue = attemptedValue;
    }
}

// ===== Password Value Objects =====

public class InvalidPasswordException : DomainException
{
    public InvalidPasswordException(string message) 
        : base($"Invalid password: {message}")
    {
    }
}

public class InvalidPasswordHashException : DomainException
{
    public InvalidPasswordHashException(string message) 
        : base($"Invalid password hash: {message}")
    {
    }
}

// ===== UserId Value Object =====
public class InvalidUserIdException : DomainException
{
    public InvalidUserIdException(string message) 
        : base($"Invalid user ID: {message}")
    {
    }
}

// ===== JwtToken Value Object =====
public class InvalidJwtTokenException : DomainException
{
    public InvalidJwtTokenException(string message) 
        : base($"Invalid JWT token: {message}")
    {
    }
    
    public InvalidJwtTokenException(string message, Exception innerException) 
        : base($"Invalid JWT token: {message}", innerException)
    {
    }
}