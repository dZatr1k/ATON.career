using Aton.Career.UserService.Models.DTO;

namespace Aton.Career.UserService.Services.Interfaces;

public interface IAuthService
{
    Task<string> Login(LoginDto dto, HttpResponse response);
}
