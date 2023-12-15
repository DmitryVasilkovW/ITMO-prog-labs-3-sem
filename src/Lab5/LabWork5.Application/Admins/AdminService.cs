using LabWork5.Application.Abstractions;
using LabWork5.Application.Contracts.Admins;
using LabWork5.Application.Contracts.Users;

namespace LabWork5.Application.Admins;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _repository;

    public AdminService(IAdminRepository repository)
    {
        _repository = repository;
    }

    public LoginResult Login(string password)
    {
        if (!_repository.PasswordVerification(password))
        {
            return LoginResult.IncorrectPassword;
        }

        return LoginResult.Success;
    }
}