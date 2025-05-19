using Microsoft.EntityFrameworkCore;
using UserService.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Aton.Career.UserService.Data;

public class UserRepository(AppDbContext context) : IUserRepository
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<IEnumerable<User>> GetAllActive()
    {
        return await _context.Users
            .Where(u => u.RevokedOn == null)
            .OrderBy(u => u.CreatedOn)
            .ToListAsync();
    }

    public async Task<IEnumerable<User>> GetUsersOlderThan(int age)
    {
        var cutoffDate = DateTime.UtcNow.AddYears(-age);
        return await _context.Users
            .Where(u => u.Birthday != null && u.Birthday <= cutoffDate)
            .ToListAsync();
    }

    public async Task<User?> GetById(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User?> GetByLogin(string login)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
    }

    public async Task Add(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}
