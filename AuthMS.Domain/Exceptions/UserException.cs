using System.Diagnostics.Contracts;

namespace AuthMS.Domain.Exceptions;

public class UserNotFoundException: DomainException
{
    public UserNotFoundException(string userId)
        : base($"User with ID '{userId}' was not found.") { }
    public UserNotFoundException(string field, string value)
        : base($"User with {field} '{value}' was not found.") {}
}

public class UserAlreadyExsistsException : DomainException
{
    public string Login {get;}

    public UserAlreadyExsistsException(string login) 
        : base($"User with login '{login}' already exists.")
    {
        Login = login;
    }
}

public class ValidationException: DomainException
    {
        public ValidationException(string name) 
        : base($"Invalid name"){ }
    }

public class InvalidCredentialsException: DomainException
    {
        public InvalidCredentialsException(string login) 
        : base($"Invalid login or password"){ }
    }