using Aton.Career.UserService.Models.Queries;
using Aton.Career.UserService.Models.Responses;
using UserService.Models;

namespace Aton.Career.UserService.Services.Interfaces;

public interface IUserQueryService
{
    Task<IEnumerable<User>> GetFilteredUsers(UserFilterQuery filter, UserOrderQuery order);
    Task<UserByLoginResponse> GetUserByLogin(string userLogin);
    Task<User> GetMe(string currentLogin);
}
