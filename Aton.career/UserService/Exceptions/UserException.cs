namespace Aton.Career.UserService.Exceptions;

public class UserException : Exception
{
    public int StatusCode { get; }
    protected UserException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
}
