using LabWork5.Application.Abstractions;
using LabWork5.Application.Contracts.Users;
using LabWork5.Application.Models.Users;

namespace LabWork5.Application.Users;

internal class UserService : IUserService
{
    private readonly CurrentUserManager _currentUserManager;
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository, CurrentUserManager currentUserManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
    }

    public LoginResult Login(long billid, string password)
    {
        User? user = _repository.FindUserByBillid(billid);

        if (user is null)
        {
            return LoginResult.NotFound;
        }

        if (!_repository.PasswordVerification(billid, password))
        {
            return LoginResult.IncorrectPassword;
        }

        _currentUserManager.User = user;
        return LoginResult.Success;
    }

    public void BillCreation(string password)
    {
        _repository.BillCreation(password, _currentUserManager.User);
    }

    public decimal ViewBalance(long billid)
    {
        return _repository.ViewBalance(billid);
    }

    public TransactionResults Withdrawal(long billid, long withdrawals)
    {
        return _repository.Withdrawal(billid, withdrawals, _currentUserManager.User);
    }

    public void AccountFunding(long billid, long depositmoney)
    {
        _repository.AccountFunding(billid, depositmoney, _currentUserManager.User);
    }

    public IList<string>? TransactionHistory()
    {
        if (_currentUserManager is not null) return _repository.TransactionHistory(_currentUserManager.User);
        return null;
    }
}