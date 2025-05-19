using UserService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Aton.Career.UserService.Services;
using Aton.Career.UserService.Models;

namespace Aton.Career.UserService.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController(IUserCreationService userCreationService, IUserQueryService userQueryService) : ControllerBase
{
    private readonly IUserCreationService _userCreationService = userCreationService;
    private readonly IUserQueryService _userQueryService = userQueryService;

    private string _currentLogin => HttpContext.User.Identity?.Name!;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserCreateDto dto)
    {
        await _userCreationService.CreateUser(dto, _currentLogin);

        return Created();
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("active")]
    public async Task<IActionResult> GetAllActive()
    {
        var activeUsers = await _userQueryService.GetActiveUsers();

        return Ok(activeUsers);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("by-login/{login}")]
    public async Task<IActionResult> GetByLogin(string login)
    {
        var user = await _userQueryService.GetUserByLogin(login);

        return Ok(user);
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetMe([FromQuery] MeQuery dto)
    {
        var me = await _userQueryService.GetMe(dto, _currentLogin);

        return Ok(me);
    }

    [HttpGet("older-than")]
    public async Task<IActionResult> GetAllOlderThan([FromQuery] UsersOlderThanQuery dto)
    {
        var users = await _userQueryService.GetUsersOlderThan(dto.Age);
        return Ok(users);
    }
}