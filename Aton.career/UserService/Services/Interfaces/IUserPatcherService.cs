using Aton.Career.UserService.Models.DTO;

namespace Aton.Career.UserService.Services.Interfaces;

public interface IUserPatcherService
{
    Task PatchUser(string login, UserPatchDto dto);
    Task UpdateLogin(HttpResponse response, string targetLogin, string newLogin);
    Task UpdatePassword(HttpResponse response, string currentLogin,string targetLogin, UpdatePasswordDto dto);
    Task ActivateUser(string login, string revokedBy);
}
