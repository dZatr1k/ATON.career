using Aton.Career.UserService.Data.Interfaces;
using Aton.Career.UserService.Exceptions;
using Aton.Career.UserService.Infrastructure.Interfaces;
using Aton.Career.UserService.Models.DTO;
using Aton.Career.UserService.Services.Interfaces;

namespace Aton.Career.UserService.Services;
public class UserPatcherService(IUserRepository repository, IPasswordHasher passwordHasher) : IUserPatcherService
{
    private readonly IUserRepository _repository = repository;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;

    public async Task ActivateUser(string login, string revokedBy)
    {
        var user = await _repository.GetByLogin(login);
        if(user == null)
            throw new NotFoundException("Пользователь с таким логином не существует");
        if (user.RevokedOn == null)
            throw new ForbiddenException("Пользователь не был удалён.");
        
        await _repository.ActivateUser(user);
    }

    public async Task PatchUser(string login, UserPatchDto dto)
    {
        var user = await _repository.GetByLogin(login);
        if (user == null)
            throw new NotFoundException("Пользователь с таким логином не существует");
        await _repository.Update(user, dto);
    }

    public async Task UpdateLogin(HttpResponse response, string targetLogin, string newLogin)
    {
        var user = await _repository.GetByLogin(targetLogin);
        if (user == null)
            throw new NotFoundException("Пользователь с таким логином не существует");
        await _repository.UpdateLogin(user, newLogin);

        response.Cookies.Delete("X-Access-Token");
    }

    public async Task UpdatePassword(HttpResponse response, string currentLogin, string targetLogin, UpdatePasswordDto dto)
    {
        var currentUser = await _repository.GetByLogin(currentLogin);
        var targetUser = await _repository.GetByLogin(targetLogin);

        if (currentUser == null)
            throw new NotFoundException("Пользователь с таким логином не существует");
        
        if (targetUser == null)
            throw new NotFoundException("Пользователь с таким логином не существует");
        
        if (!currentUser.Admin || targetUser.Admin)
            if (!_passwordHasher.Verify(dto.OldPassword, targetUser.Password))
                throw new ForbiddenException("Старый пароль неверный.");

        await _repository.UpdatePassword(targetUser, _passwordHasher.Generate(dto.NewPassword));

        response.Cookies.Delete("X-Access-Token");
    }
}
