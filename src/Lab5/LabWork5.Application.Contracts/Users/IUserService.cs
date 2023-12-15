namespace LabWork5.Application.Contracts.Users;

public interface IUserService
{
    LoginResult Login(long billid, string password);
    void BillCreation(long billid);
    long ViewBalance(long billid);
    TransactionResults Withdrawal(long billid, long withdrawals);
    void AccountFunding(long billid, long depositmoney);
    IList<string> TransactionHistory(long billid);
}