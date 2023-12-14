using LabWork5.Application.Contracts.Users;
using LabWork5.Application.Models.Users;

namespace LabWork5.Application.Abstractions;

public interface IUserRepository
{
    User? FindUserByBillid(long billid);
    void BillCreation(long billid);
    long ViewBalance(long billid);
    TransactionResults Withdrawal(long billid, long withdrawals);
    void AccountFunding(long billid, long depositmoney);
    IList<string> TransactionHistory(long billid);
}