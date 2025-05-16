using Aton.Career.UserService.Data;
using Aton.Career.UserService.Infrastructure;
using Aton.Career.UserService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Aton.Career.UserService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IUserRepository repository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider) : ControllerBase
{
    private readonly IUserRepository _repository = repository;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var user = await _repository.GetByLogin(dto.Login);

        if (user == null || !_passwordHasher.Verify(dto.Password, user.Password))
            return Unauthorized("Неверный логин или пароль");

        var token = _jwtProvider.GenerateToken(user);

        HttpContext.Response.Cookies.Append("X-Access-Token", token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Path = "/",
            Expires = DateTimeOffset.UtcNow.AddDays(1)
        });

        return Ok(token);
    }


}
