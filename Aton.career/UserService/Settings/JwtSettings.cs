namespace Aton.Career.UserService.Settings;

public class JwtSettings
{
    public required string Key { get; init; }
    public required int ExpireHours { get; init; }
}
