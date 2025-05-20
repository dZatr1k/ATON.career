namespace Aton.Career.UserService.Services.Interfaces;

public interface IUserContextService
{
    string? Login { get; }
    string? Role { get; }
    IDictionary<string, string> RouteValues { get; }
}
