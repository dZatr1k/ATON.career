using Aton.Career.UserService.Exceptions;
using Aton.Career.UserService.Data.Interfaces;
using Aton.Career.UserService.Infrastructure.Interfaces;
using Aton.Career.UserService.Services.Interfaces;
using Aton.Career.UserService.Models.DTO;

namespace Aton.Career.UserService.Services;

public class AuthService(IUserRepository repository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider) : IAuthService
{
    private readonly IUserRepository _repository = repository;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<string> Login(LoginDto dto, HttpResponse response)
    {
        var user = await _repository.GetByLogin(dto.Login);

        if (user == null || !_passwordHasher.Verify(dto.Password, user.Password))
            throw new UnauthorizedException("Неверный логин или пароль");

        var token = _jwtProvider.GenerateToken(user);

        response.Cookies.Append("X-Access-Token", token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Path = "/",
            Expires = DateTimeOffset.UtcNow.AddDays(1)
        });

        return token;
    }
}
