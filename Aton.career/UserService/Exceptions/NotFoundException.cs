namespace Aton.Career.UserService.Exceptions;

public class NotFoundException : UserException
{
    public NotFoundException(string message) : base(message, StatusCodes.Status404NotFound) { }
}
