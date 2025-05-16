using UserService.Models;
using Microsoft.AspNetCore.Mvc;
using Aton.Career.UserService.Data;
using Aton.Career.UserService.Infrastructure;
using Microsoft.AspNetCore.Authorization;

namespace Aton.Career.UserService.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController(IUserRepository repository, IPasswordHasher passwordHasher) : ControllerBase
{
    private readonly IUserRepository _repository = repository;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserCreateDto dto)
    {
        string currentLogin = "Admin";

        var existing = await _repository.GetByLogin(dto.Login);
        if (existing != null)
            return Conflict("Пользователь с таким логином уже существует.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            Login = dto.Login,
            Password = _passwordHasher.Generate(dto.Password),
            Name = dto.Name,
            Gender = dto.Gender,
            Birthday = dto.Birthday == null ? null : DateTime.SpecifyKind(dto.Birthday.Value, DateTimeKind.Utc),
            Admin = dto.Admin,
            CreatedOn = DateTime.UtcNow,
            CreatedBy = currentLogin,
            ModifiedOn = DateTime.UtcNow,
            ModifiedBy = currentLogin
        };

        await _repository.Add(user);

        return Created();
    }
}