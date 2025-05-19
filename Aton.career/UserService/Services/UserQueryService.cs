using Aton.Career.UserService.Data;
using Aton.Career.UserService.Exceptions;
using Aton.Career.UserService.Infrastructure;
using Aton.Career.UserService.Models;
using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace Aton.Career.UserService.Services;

public class UserQueryService(IUserRepository repository, IUserQueryBuilder userQueryBuilder) : IUserQueryService
{
    private readonly IUserRepository _repository = repository;
    private readonly IUserQueryBuilder _userQueryBuilder = userQueryBuilder;

    public async Task<IEnumerable<User>> GetFilteredUsers(UserFilterQuery filter, UserOrderQuery order)
    {
        var query = _repository.GetQueryable();

        query = _userQueryBuilder.ApplyFilter(query, filter);
        query = _userQueryBuilder.ApplySorting(query, order);

        return await query.ToListAsync();
    }

    public async Task<User> GetMe(string currentLogin)
    {   
        var user = await _repository.GetByLogin(currentLogin);

        if(user == null)
            throw new NotFoundException($"Пользователь {currentLogin} не найден или удалён.");

        if (user.RevokedOn != null)
            throw new ForbiddenException("Пользователь был удален.");

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
}
