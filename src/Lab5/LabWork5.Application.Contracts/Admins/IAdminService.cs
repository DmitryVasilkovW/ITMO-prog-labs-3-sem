using LabWork5.Application.Contracts.Users;

namespace LabWork5.Application.Contracts.Admins;

public interface IAdminService
{
    LoginResult Login(string password);
    IList<string> TransactionHistory(long userid);
}