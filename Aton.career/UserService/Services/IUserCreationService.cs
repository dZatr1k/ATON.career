using UserService.Models;

namespace Aton.Career.UserService.Services;

public interface IUserCreationService
{
    Task CreateUser(UserCreateDto dto, string currentLogin);
}
