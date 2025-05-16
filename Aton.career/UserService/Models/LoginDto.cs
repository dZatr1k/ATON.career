using System.ComponentModel.DataAnnotations;

namespace Aton.Career.UserService.Models;

public class LoginDto
{
    [Required]
    public string Login { get; init; } = null!;

    [Required]
    public string Password { get; init; } = null!;
}
