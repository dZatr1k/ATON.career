using System.ComponentModel.DataAnnotations;

namespace UserService.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Логин должен содержать только латинские буквы и цифры.")]
    public string Login { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    [Required]
    [RegularExpression("^[a-zA-Zа-яА-Я]+$", ErrorMessage = "Имя должно содержать только кирилицу или лантиские буквы.")]
    public string Name { get; set; } = string.Empty;

    [Range(0, 2)]
    public int Gender { get; set; }

    public DateTime? Birthday { get; set; }

    public bool Admin { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public string CreatedBy { get; set; } = string.Empty;

    public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;

    public string ModifiedBy { get; set; } = string.Empty;

    public DateTime? RevokedOn { get; set; }

    public string? RevokedBy { get; set; }
}
