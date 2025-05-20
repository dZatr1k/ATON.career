namespace Aton.Career.UserService.Exceptions;

public class ConflictException : UserException
{
    public ConflictException(string message) : base(message, StatusCodes.Status409Conflict) { }
}
