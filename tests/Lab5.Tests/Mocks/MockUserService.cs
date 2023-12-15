using System.Collections.Generic;
using LabWork5.Application.Contracts.Users;
using LabWork5.Application.Models.Users;

namespace LabWork5.Infrastructure.DataAccess.Repositories;

public class MockUserService
{
    private readonly MockUserRepository _repository = new MockUserRepository();

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

        return LoginResult.Success;
    }

    public void BillCreation(string password)
    {
        _repository.BillCreation(password, new User(239, "TMP"));
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

    public IList<string>? TransactionHistory()
    {
        return _repository.TransactionHistory(new User(239, "TMP"));
    }

    public long? MockViewBalance(long billid)
    {
        return _repository.MockViewBalance(billid);
    }
}