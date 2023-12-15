using System.Collections.Generic;
using LabWork5.Application.Abstractions;
using LabWork5.Application.Contracts.Users;
using LabWork5.Application.Models.Users;

namespace LabWork5.Infrastructure.DataAccess.Repositories;

public class MockUserRepository : IUserRepository
{
    private MockDatabase _database = new MockDatabase();
    public User? FindUserByBillid(long billid)
    {
        return null;
    }

    public void BillCreation(string password, User? user)
    {
    }

    public long ViewBalance(long billid)
    {
        return 0;
    }

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

    public void AccountFunding(long billid, long depositmoney)
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

    public IList<string>? TransactionHistory(User? user)
    {
        return null;
    }

    public bool PasswordVerification(long billid, string inputpassword)
    {
        return false;
    }

    public long? MockViewBalance(long billid)
    {
        var billtable = new MockBillTable();
        _database.AddTable(billtable);

        return _database.FindBalanceByID(billid);
    }
}