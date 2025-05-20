using Aton.Career.UserService.Services.Interfaces;
using System.Security.Claims;

namespace Aton.Career.UserService.Services;

public class UserContextService(IHttpContextAccessor httpContextAccessor) : IUserContextService
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public string? Login => _httpContextAccessor.HttpContext?.User?.Identity?.Name;
    public string? Role => _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Role)?.Value;
    public IDictionary<string, string> RouteValues =>
        _httpContextAccessor.HttpContext?.Request.RouteValues.ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value?.ToString() ?? ""
        ) ?? new Dictionary<string, string>();
}
