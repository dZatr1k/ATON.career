namespace Aton.Career.UserService.Models.DTO;
public class UpdatePasswordDto
{
    public string OldPassword { get; init; } = null!;
    public string NewPassword { get; init; } = null!;
}
