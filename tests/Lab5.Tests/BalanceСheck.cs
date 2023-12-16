using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using LabWork5.Application.Contracts.Users;
using LabWork5.Infrastructure.DataAccess.Repositories;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class BalanceСheck : IEnumerable<object[]>
{
    public static IEnumerable<object[]> GetCommands
    {
        get
        {
            yield return new object[]
        {
            10,
            10000000,
            20,
        };
        }
    }

    public static bool ResultsVerification(ICommand expectedvalue, ICommand? result)
    {
        if (expectedvalue.Equals(result))
        {
            return true;
        }

        return false;
    }

    IEnumerator<object[]> IEnumerable<object[]>.GetEnumerator()
    {
        throw new ArgumentOutOfRangeException();
    }

    public IEnumerator GetEnumerator()
    {
        return GetEnumerator();
    }

    [Theory]
    [MemberData(nameof(GetCommands), MemberType = typeof(BalanceСheck))]
    public void BalanceСhecker(
        long withdrawableamount,
        long cashthatcannotbewithdrawn,
        long creditamount)
    {
        var user = new MockUserService();
        TransactionResults result = user.Withdrawal(239, withdrawableamount);
        TransactionResults transactionexpectedresult = TransactionResults.Success;

        Assert.Equal(result, transactionexpectedresult);
        Assert.Equal(990, user.MockViewBalance(239));

        transactionexpectedresult = TransactionResults.InsufficientFunds;
        result = user.Withdrawal(239, cashthatcannotbewithdrawn);

        Assert.Equal(result, transactionexpectedresult);

        user.AccountFunding(creditamount);
        Assert.Equal(1010, user.MockViewBalance(239));
    }
}