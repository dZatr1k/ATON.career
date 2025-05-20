using Aton.Career.UserService.Models.Queries;
using UserService.Models;

namespace Aton.Career.UserService.Infrastructure.Interfaces;
public interface IUserQueryBuilder
{
    IQueryable<User> ApplyFilter(IQueryable<User> query, UserFilterQuery filter);
    IQueryable<User> ApplySorting(IQueryable<User> query, UserOrderQuery order);
}
