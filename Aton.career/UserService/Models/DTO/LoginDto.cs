using System.ComponentModel.DataAnnotations;

namespace Aton.Career.UserService.Models.DTO;

public class LoginDto
{
    [Required]
    [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Логин должен содержать только латинские буквы и цифры.")]
    public string Login { get; init; } = null!;

    [Required]
    [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Пароль должен содержать только лантиские буквы и цифры.")]
    public string Password { get; init; } = null!;
}
