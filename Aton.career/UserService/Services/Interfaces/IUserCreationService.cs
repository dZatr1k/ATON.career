using Aton.Career.UserService.Models.DTO;
using UserService.Models;

namespace Aton.Career.UserService.Services.Interfaces;

public interface IUserCreationService
{
    Task<User> CreateUser(UserCreateDto dto, string currentLogin);
}
