using Aton.Career.UserService.Models.DTO;
using UserService.Models;

namespace Aton.Career.UserService.Data.Interfaces;

public interface IUserRepository
{
    IQueryable<User> GetQueryable();
    Task<User?> GetByLogin(string login);
    Task Add(User user);
    Task SoftDelete(User user, string revokedBy);
    Task HardDelete(User user);
    Task Update(User user, UserPatchDto dto);
    Task UpdateLogin(User user, string newLogin);
    Task UpdatePassword(User user, string newPassword);
    Task ActivateUser(User user);
}
