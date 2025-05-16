namespace Aton.Career.UserService.Infrastructure;

public interface IPasswordHasher
{
    string Generate(string password);
    bool Verify(string password, string hashedPassword);
}
