using Aton.Career.UserService.Models;

namespace Aton.Career.UserService.Services;

public interface IAuthService
{
    Task<string> Login(LoginDto dto, HttpResponse response);
}
