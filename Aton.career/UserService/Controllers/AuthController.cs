using Aton.Career.UserService.Data;
using Aton.Career.UserService.Infrastructure;
using Aton.Career.UserService.Models;
using Aton.Career.UserService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
