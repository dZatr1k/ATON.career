using Aton.Career.UserService.Models.DTO;
using Aton.Career.UserService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aton.Career.UserService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var token = await _authService.Login(dto, HttpContext.Response);

        return Ok(token);
    }


}
