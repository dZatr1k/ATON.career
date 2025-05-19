using System.ComponentModel.DataAnnotations;

namespace Aton.Career.UserService.Models;
public class UserByLoginRespone
{
    public string Name { get; init; } = string.Empty;

    public int Gender { get; init; }

    public DateTime? Birthday { get; init; }

    public bool IsActive { get; init; }
}
