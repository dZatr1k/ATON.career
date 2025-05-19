using Aton.Career.UserService.Data;
using Aton.Career.UserService.Exceptions;
using Aton.Career.UserService.Models;

namespace Aton.Career.UserService.Services;
public class UserPatcherService(IUserRepository repository) : IUserPatcherService
{
    private readonly IUserRepository _repository = repository;

    public async Task PatchUser(string login, UserPatchDto dto)
    {
        var user = await _repository.GetByLogin(login);
        if (user == null)
            throw new NotFoundException("Пользователь с таким логином не существует");
        await _repository.Update(user, dto);
    }
}
