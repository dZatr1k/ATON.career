using Aton.Career.UserService.Data.Interfaces;
using Aton.Career.UserService.Exceptions;
using Aton.Career.UserService.Services.Interfaces;

namespace Aton.Career.UserService.Services;
public class UserDeletionService(IUserRepository repository) : IUserDeletionService
{
    private readonly IUserRepository _repository = repository;

    public async Task HardDeleteUserByLogin(string userLogin)
    {
        var user = await _repository.GetByLogin(userLogin);

        if (user == null)
            throw new NotFoundException("Пользователь с таким логином не существует");

        await _repository.HardDelete(user);
    }

    public async Task SoftDeleteUserByLogin(string userLogin, string revokedBy)
    {
        var user = await _repository.GetByLogin(userLogin);

        if (user == null)
            throw new NotFoundException("Пользователь с таким логином не существует");

        await _repository.SoftDelete(user, revokedBy);
    }
}
