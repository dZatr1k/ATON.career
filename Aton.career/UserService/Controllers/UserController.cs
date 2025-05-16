using UserService.Models;
using Microsoft.AspNetCore.Mvc;
using Aton.Career.UserService.Data;
using Aton.Career.UserService.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Aton.Career.UserService.Services;

namespace Aton.Career.UserService.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController(IUserCreationService userCreationService) : ControllerBase
{
    private readonly IUserCreationService _userCreationService = userCreationService;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserCreateDto dto)
    {
        string currentLogin = HttpContext.User.Identity?.Name!;

        await _userCreationService.CreateUser(dto, currentLogin);

        return Created();
    }
}