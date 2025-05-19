using System.ComponentModel.DataAnnotations;

namespace Aton.Career.UserService.Models;

public class UsersOlderThanQuery
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Возраст должен быть положительным числом")]
    public int Age { get; init; }
}
