namespace LabWork5.Application.Contracts.Users;

public interface IUserService
{
    LoginResult Login(long billid);
}