using Aton.Career.UserService.Data;
using Aton.Career.UserService.Exceptions;
using Aton.Career.UserService.Infrastructure;
using Aton.Career.UserService.Models;
using UserService.Models;

namespace Aton.Career.UserService.Services;

public class UserQueryService(IUserRepository repository, IPasswordHasher passwordHasher) : IUserQueryService
{
    private readonly IUserRepository _repository = repository;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;

    public async Task<IEnumerable<User>> GetActiveUsers()
    {
        return await _repository.GetAllActive();
    }

    public async Task<User> GetMe(MeQuery meDto, string currentLogin)
    {
        if(meDto.Login != currentLogin)
            throw new UnauthorizedException("Вы не можете получить информацию о себе, используя чужой логин");
        
        var user = await _repository.GetByLogin(meDto.Login);

        if (user == null || user.RevokedOn != null)
            throw new ForbiddenException("Пользователь был удален");

        if (!_passwordHasher.Verify(meDto.Password, user.Password))
            throw new UnauthorizedException("Неверный логин или пароль");

        return user;
    }

    public async Task<UserByLoginRespone> GetUserByLogin(string userLogin)
    {
        var user = await _repository.GetByLogin(userLogin);

        if (user == null)
            throw new NotFoundException("Пользователь с таким логином не существует");

        return new UserByLoginRespone
        {
            Birthday = user.Birthday,
            Gender = user.Gender,
            Name = user.Name,
            IsActive = user.RevokedOn == null
        };
    }

    public async Task<IEnumerable<User>> GetUsersOlderThan(int age)
    {
        return await _repository.GetUsersOlderThan(age);
    }
}
