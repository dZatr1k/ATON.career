namespace Aton.Career.UserService.Models.Responses;
public class UserByLoginResponse
{
    public string Name { get; init; } = string.Empty;

    public int Gender { get; init; }

    public DateTime? Birthday { get; init; }

    public bool IsActive { get; init; }
}
