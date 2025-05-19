namespace Aton.Career.UserService.Models;
public class UpdatePasswordDto
{
    public string OldPassword { get; init; } = null!;
    public string NewPassword { get; init; } = null!;
}
