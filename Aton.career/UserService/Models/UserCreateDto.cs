using System.ComponentModel.DataAnnotations;

namespace UserService.Models;

public class UserCreateDto
{
    [Required]
    [MinLength(3, ErrorMessage = "Логин должен содержать минимум 3 символа.")]
    [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Логин должен содержать только латинские буквы и цифры.")]
    public string Login { get; init; } = null!;

    [Required]
    [MinLength(8, ErrorMessage = "Пароль должен содержать минимум 8 символов.")]
    [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Пароль должен содержать только лантиские буквы и цифры.")]
    public string Password { get; init; } = null!;

    [Required]
    [RegularExpression(@"^[a-zA-Zа-яА-ЯёЁ]+$", ErrorMessage = "Имя должно содержать только кирилицу или лантиские буквы.")]
    public string Name { get; init; } = null!;

    [Required]
    [Range(0, 2)]
    public int Gender { get; init; }

    public DateTime? Birthday { get; init; }

    public bool Admin { get; init; }
}