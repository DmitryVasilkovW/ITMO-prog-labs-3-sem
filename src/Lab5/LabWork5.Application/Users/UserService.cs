using LabWork5.Application.Abstractions;
using LabWork5.Application.Contracts.Users;
using LabWork5.Application.Models.Users;

namespace LabWork5.Application.Users;

internal class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly CurrentUserManager _currentUserManager;

    public UserService(IUserRepository repository, CurrentUserManager currentUserManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
    }

    public LoginResult Login(long billid)
    {
        User? user = _repository.FindUserByBillid(billid);

        if (user is null)
        {
            return LoginResult.NotFound;
        }

        _currentUserManager.User = user;
        return LoginResult.Success;
    }

    public void BillCreation(long billid)
    {
        _repository.BillCreation(billid);
    }

    public long ViewBalance(long billid)
    {
        return _repository.ViewBalance(billid);
    }

    public TransactionResults Withdrawal(long billid, long withdrawals)
    {
        return _repository.Withdrawal(billid, withdrawals);
    }

    public void AccountFunding(long billid, long depositmoney)
    {
        _repository.AccountFunding(billid, depositmoney);
    }

    public IList<string> TransactionHistory(long billid)
    {
        return _repository.TransactionHistory(billid);
    }
}