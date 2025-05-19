using UserService.Models;

namespace Aton.Career.UserService.Services;

public interface IUserCreationService
{
    Task<User> CreateUser(UserCreateDto dto, string currentLogin);
}
