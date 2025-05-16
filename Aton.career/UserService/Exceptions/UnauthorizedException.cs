namespace Aton.Career.UserService.Exceptions;

public class UnauthorizedException : UserException
{
    public UnauthorizedException(string message) : base(message, StatusCodes.Status401Unauthorized) { }
}
