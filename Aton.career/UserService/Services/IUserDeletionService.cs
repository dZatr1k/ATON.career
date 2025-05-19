namespace Aton.Career.UserService.Services;

public interface IUserDeletionService
{
    Task SoftDeleteUserByLogin(string userLogin, string revokedBy);
    Task HardDeleteUserByLogin(string userLogin);

}
