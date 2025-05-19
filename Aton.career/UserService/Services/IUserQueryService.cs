using Aton.Career.UserService.Models;
using UserService.Models;

namespace Aton.Career.UserService.Services;

public interface IUserQueryService
{
    Task<IEnumerable<User>> GetFilteredUsers(UserFilterQuery filter, UserOrderQuery order);
    Task<UserByLoginRespone> GetUserByLogin(string userLogin);
    Task<User> GetMe(string currentLogin);
}
