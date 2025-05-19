using Aton.Career.UserService.Models;
using UserService.Models;

namespace Aton.Career.UserService.Infrastructure;
public interface IUserQueryBuilder
{
    IQueryable<User> ApplyFilter(IQueryable<User> query, UserFilterQuery filter);
    IQueryable<User> ApplySorting(IQueryable<User> query, UserOrderQuery order);
}
