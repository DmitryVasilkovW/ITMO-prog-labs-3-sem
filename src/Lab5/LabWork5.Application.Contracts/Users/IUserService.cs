namespace LabWork5.Application.Contracts.Users;

public interface IUserService
{
    LoginResult Login(long billid, string password);
    void BillCreation(string password);
    decimal ViewBalance(long billid);
    TransactionResults Withdrawal(long billid, long withdrawals);
    void AccountFunding(long billid, long depositmoney);
    public IList<string>? TransactionHistory();
}