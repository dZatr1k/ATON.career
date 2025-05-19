using Aton.Career.UserService.Models;
using UserService.Models;

namespace Aton.Career.UserService.Data;

public interface IUserRepository
{
    IQueryable<User> GetQueryable();
    Task<User?> GetByLogin(string login);
    Task Add(User user);
    Task SoftDelete(User user, string revokedBy);
    Task HardDelete(User user);
    Task Update(User user, UserPatchDto dto);
}
