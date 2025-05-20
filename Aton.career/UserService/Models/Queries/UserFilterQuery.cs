namespace Aton.Career.UserService.Models.Queries;

public class UserFilterQuery
{
    public UserStatus? Status { get; init; }
    public int? MinAge { get; init; }
}

public enum UserStatus
{
    Active,
    Deleted,
}
