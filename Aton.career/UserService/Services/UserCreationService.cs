using Aton.Career.UserService.Data.Interfaces;
using Aton.Career.UserService.Exceptions;
using Aton.Career.UserService.Infrastructure.Interfaces;
using Aton.Career.UserService.Models.DTO;
using Aton.Career.UserService.Services.Interfaces;
using UserService.Models;

namespace Aton.Career.UserService.Services;

public class UserCreationService(IUserRepository repository, IPasswordHasher passwordHasher) : IUserCreationService
{
    private readonly IUserRepository _repository = repository;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;

    public async Task<User> CreateUser(UserCreateDto dto, string currentLogin)
    {
        var existing = await _repository.GetByLogin(dto.Login);
        if (existing != null)
            throw new ConflictException("Пользователь с таким логином уже существует.");

        var currentUser = await _repository.GetByLogin(currentLogin);

        if(currentUser == null)
            throw new NotFoundException($"Пользователь {currentLogin} не найден или удалён.");

        if (!currentUser.Admin && dto.Admin)
            throw new ForbiddenException("Вы не можете создать администратора, если сами не являетесь администратором.");

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

        return user;
    }
}
