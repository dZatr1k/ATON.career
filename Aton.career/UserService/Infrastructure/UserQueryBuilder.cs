using Aton.Career.UserService.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using UserService.Models;

namespace Aton.Career.UserService.Infrastructure;
public class UserQueryBuilder : IUserQueryBuilder
{
    private IQueryable<User> ApplyStatusFilter(IQueryable<User> query, UserStatus status)
    {
        return status switch
        {
            UserStatus.Deleted => query.Where(u => u.RevokedOn != null),
            UserStatus.Active => query.Where(u => u.RevokedOn == null),
            _ => throw new NotImplementedException("Неизвестный параметр фильтра")
        };
    }

    private IQueryable<User> ApplyAgeFilter(IQueryable<User> query, int age)
    {
        var minDate = DateTime.UtcNow.AddYears(-age);
        return query.Where(u => u.Birthday != null && u.Birthday <= minDate);
    }

    public IQueryable<User> ApplyFilter(IQueryable<User> query, UserFilterQuery filter)
    {
        if(filter.Status != null)
            query = ApplyStatusFilter(query, filter.Status.Value);

        if (filter.MinAge != null)
            query = ApplyAgeFilter(query, filter.MinAge.Value);

        return query;
    }

    public IQueryable<User> ApplySorting(IQueryable<User> query, UserOrderQuery order)
    {
        if(order.SortBy == null)
            return query;

        query = order.SortBy switch
        {
            UserSortBy.Name => query.OrderBy(u => u.Name),
            UserSortBy.Birthday => query.OrderBy(u => u.Birthday),
            UserSortBy.Login => query.OrderBy(u => u.Login),
            UserSortBy.CreatedOn => query.OrderBy(u => u.CreatedOn),
            UserSortBy.ModifiedOn => query.OrderBy(u => u.ModifiedOn),
            _ => throw new NotImplementedException("Неизвестный параметр сортировки")
        };

        if (order.SortOrder != null)
            if (order.SortOrder == UserSortOrder.Desc)
                query = query.Reverse();

        return query;
    }
}
