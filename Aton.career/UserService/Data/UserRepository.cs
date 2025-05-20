using Aton.Career.UserService.Data.Interfaces;
using Aton.Career.UserService.Models.DTO;
using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace Aton.Career.UserService.Data;

public class UserRepository(AppDbContext context) : IUserRepository
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.Users.ToListAsync();
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

    public async Task SoftDelete(User user, string revokedBy)
    {
        user.RevokedOn = DateTime.UtcNow;
        user.RevokedBy = revokedBy;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task HardDelete(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public IQueryable<User> GetQueryable()
    {
        return _context.Users.AsQueryable();
    }

    public async Task Update(User user, UserPatchDto dto)
    {
        if(dto.Name != null) user.Name = dto.Name;
        if (dto.Gender != null) user.Gender = dto.Gender.Value;
        if (dto.Birthday != null) user.Birthday = dto.Birthday;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateLogin(User user, string newLogin)
    {
        user.Login = newLogin;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePassword(User user, string newPassword)
    {
        user.Password = newPassword;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task ActivateUser(User user)
    {
        user.RevokedOn = null;
        user.RevokedBy = null;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}
