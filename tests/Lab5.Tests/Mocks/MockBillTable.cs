namespace LabWork5.Infrastructure.DataAccess.Repositories;

public class MockBillTable : IMockTable
{
    public MockBillTable()
    {
        Name = "Bill";
        ID = 1;
        Billid = 239;
        Balance = 1000;
    }

    public string? Name { get; }
    public long ID { get; }
    public long Billid { get; }
    public long Balance { get; private set; }

    public void ReduceBalance(long withdrawals)
    {
        Balance -= withdrawals;
    }

    public void IncreaseBalance(long depositmoney)
    {
        Balance += depositmoney;
    }
}