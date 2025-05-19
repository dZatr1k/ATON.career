using Aton.Career.UserService.Models;
using UserService.Models;

namespace Aton.Career.UserService.Services;

public interface IUserQueryService
{
    Task<IEnumerable<User>> GetActiveUsers();
    Task<IEnumerable<User>> GetUsersOlderThan(int age);
    Task<UserByLoginRespone> GetUserByLogin(string userLogin);
    Task<User> GetMe(MeQuery meDto, string currentLogin);
}
