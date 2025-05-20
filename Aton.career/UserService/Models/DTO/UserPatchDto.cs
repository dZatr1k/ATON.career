using System.ComponentModel.DataAnnotations;

namespace Aton.Career.UserService.Models.DTO;
public class UserPatchDto
{
    [RegularExpression(@"^[a-zA-Zа-яА-ЯёЁ]+$", ErrorMessage = "Имя должно содержать только кирилицу или лантиские буквы.")]
    public string? Name { get; init; } = null!;

    [Range(0, 2)]
    public int? Gender { get; init; }

    public DateTime? Birthday { get; init; }
}
