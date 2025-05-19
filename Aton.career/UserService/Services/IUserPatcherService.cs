using Aton.Career.UserService.Models;

namespace Aton.Career.UserService.Services;

public interface IUserPatcherService
{
    Task PatchUser(string login, UserPatchDto dto);
    Task UpdateLogin(HttpResponse response, string targetLogin, string newLogin);
    Task UpdatePassword(HttpResponse response, string currentLogin,string targetLogin, UpdatePasswordDto dto);
}
