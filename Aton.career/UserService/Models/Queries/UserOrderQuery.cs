namespace Aton.Career.UserService.Models.Queries;
public class UserOrderQuery
{
    public UserSortBy? SortBy { get; init; }
    public UserSortOrder? SortOrder { get; init; }
}

public enum UserSortBy
{
    Login,
    Name,
    Birthday,
    CreatedOn,
    ModifiedOn
}

public enum UserSortOrder
{
    Asc,
    Desc
}
