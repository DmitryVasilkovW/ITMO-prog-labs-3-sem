using LabWork5.Application.Contracts.Users;
using LabWork5.Application.Models.Users;

namespace LabWork5.Application.Abstractions;

public interface IUserRepository
{
    User? FindUserByBillid(long billid);
    void BillCreation(string password, User? user);
    long ViewBalance(long billid);
    TransactionResults Withdrawal(long billid, long withdrawals);
    void AccountFunding(long billid, long depositmoney);
    IList<string>? TransactionHistory(User? user);
    bool PasswordVerification(long billid, string inputpassword);
}