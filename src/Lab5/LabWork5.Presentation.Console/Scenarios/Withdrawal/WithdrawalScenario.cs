using LabWork5.Application.Contracts.Users;
using Spectre.Console;

namespace LabWork5.Presentation.Console.Scenarios.Withdrawal;

public class WithdrawalScenario : IScenario
{
    private readonly IUserService _userService;

    public WithdrawalScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Withdrawal";

    public void Run()
    {
        long bill = AnsiConsole.Ask<long>("Enter your bill");
        long withdrawal = AnsiConsole.Ask<long>("enter the amount you want to withdraw");

        TransactionResults result = _userService.Withdrawal(bill, withdrawal);

        string message = result switch
        {
            TransactionResults.Success => "Success",
            TransactionResults.InsufficientFunds => "Insufficient funds",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.WriteLine("Ok");
    }
}