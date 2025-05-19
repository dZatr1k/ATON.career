using UserService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Aton.Career.UserService.Services;
using Aton.Career.UserService.Models;

namespace Aton.Career.UserService.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController(
    IUserCreationService userCreationService, 
    IUserQueryService userQueryService,
    IUserDeletionService userDeletionService
    ) : ControllerBase
{
    private readonly IUserCreationService _userCreationService = userCreationService;
    private readonly IUserQueryService _userQueryService = userQueryService;
    private readonly IUserDeletionService _userDeletionService = userDeletionService;

    private string _currentLogin => HttpContext.User.Identity!.Name!;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserCreateDto dto)
    {
        var newUser = await _userCreationService.CreateUser(dto, _currentLogin);

        return CreatedAtAction(nameof(GetByLogin), new { login = newUser.Login }, newUser);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] UserFilterQuery filter, [FromQuery] UserOrderQuery order)
    {
        var filteredUsers = await _userQueryService.GetFilteredUsers(filter, order);

        return Ok(filteredUsers);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{login}")]
    public async Task<IActionResult> GetByLogin(string login)
    {
        var user = await _userQueryService.GetUserByLogin(login);

        return Ok(user);
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetMe()
    {
        var me = await _userQueryService.GetMe(_currentLogin);

        return Ok(me);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{login}")]
    public async Task<IActionResult> SoftDelete(string login, [FromQuery] bool soft = true)
    {
        if (soft)
            await _userDeletionService.SoftDeleteUserByLogin(login, _currentLogin);
        else
            await _userDeletionService.HardDeleteUserByLogin(login);

        return NoContent();
    }
}