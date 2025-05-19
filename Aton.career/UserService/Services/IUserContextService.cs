namespace Aton.Career.UserService.Services;

public interface IUserContextService
{
    string? Login { get; }
    string? Role { get; }
    IDictionary<string, string> RouteValues { get; }
}
