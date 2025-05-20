namespace Aton.Career.UserService.Exceptions;

public class ForbiddenException : UserException
{
    public ForbiddenException(string message) : base(message, StatusCodes.Status403Forbidden) {}
}

