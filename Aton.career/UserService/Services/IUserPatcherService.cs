using Aton.Career.UserService.Models;

namespace Aton.Career.UserService.Services;

public interface IUserPatcherService
{
    Task PatchUser(string login, UserPatchDto dto);
}
