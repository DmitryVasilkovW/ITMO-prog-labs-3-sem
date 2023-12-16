using LabWork5.Application.Contracts.Users;

namespace LabWork5.Infrastructure.DataAccess.Repositories;

public class MockUserService
{
    private readonly MockUserRepository _repository = new MockUserRepository();

    public TransactionResults Withdrawal(long billid, long withdrawals)
    {
        return _repository.Withdrawal(billid, withdrawals);
    }

    public void AccountFunding(long depositmoney)
    {
        _repository.AccountFunding(depositmoney);
    }

    public long? MockViewBalance(long billid)
    {
        return _repository.MockViewBalance(billid);
    }
}