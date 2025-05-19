using UserService.Models;

namespace Aton.Career.UserService.Data;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll();
    Task<IEnumerable<User>> GetAllActive();
    Task<IEnumerable<User>> GetUsersOlderThan(int age);
    Task<User?> GetById(Guid id);
    Task<User?> GetByLogin(string login);
    Task Add(User user);
}
