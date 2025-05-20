using UserService.Models;

namespace Aton.Career.UserService.Infrastructure.Interfaces;

public interface IJwtProvider
{
    string GenerateToken(User user);
}
