using LabWork5.Application.Contracts.Users;

namespace LabWork5.Infrastructure.DataAccess.Repositories;

public class MockUserRepository
{
    private MockDatabase _database = new MockDatabase();
    public TransactionResults Withdrawal(long billid, long withdrawals)
    {
        var billtable = new MockBillTable();
        _database.AddTable(billtable);
        long? checkbalance = _database.FindBalanceByID(billid);
        if (checkbalance - withdrawals < 0)
        {
            return TransactionResults.InsufficientFunds;
        }

        if (_database.FindByName("Bill") is not null && _database.FindByName("Bill") is MockBillTable)
        {
            IMockTable? billTable = _database.FindByName("Bill");

            if (billTable is MockBillTable && billTable is not null)
            {
                ((MockBillTable)billTable).ReduceBalance(withdrawals);
            }
        }

        return TransactionResults.Success;
    }

    public void AccountFunding(long depositmoney)
    {
        var billtable = new MockBillTable();
        _database.AddTable(billtable);
        if (_database.FindByName("Bill") is not null && _database.FindByName("Bill") is MockBillTable)
        {
            IMockTable? billTable = _database.FindByName("Bill");

            if (billTable is MockBillTable && billTable is not null)
            {
                ((MockBillTable)billTable).IncreaseBalance(depositmoney);
            }
        }
    }

    public long? MockViewBalance(long billid)
    {
        var billtable = new MockBillTable();
        _database.AddTable(billtable);

        return _database.FindBalanceByID(billid);
    }
}