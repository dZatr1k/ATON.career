using UserService.Models;

namespace Aton.Career.UserService.Infrastructure;

public interface IJwtProvider
{
    string GenerateToken(User user);
}
