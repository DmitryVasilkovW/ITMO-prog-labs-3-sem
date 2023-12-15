using LabWork5.Application.Contracts.Users;
using Spectre.Console;

namespace LabWork5.Presentation.Console.Scenarios.TransactionHistory;

public class TransactionHistoryScenario : IScenario
{
    private readonly IUserService _userService;

    public TransactionHistoryScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Transaction History";

    public void Run()
    {
        long bill = AnsiConsole.Ask<long>("Enter your bill");

        IList<string> result = _userService.TransactionHistory(bill);

        foreach (string operation in result)
        {
            AnsiConsole.WriteLine(operation);
        }

        AnsiConsole.WriteLine("Ok");
    }
}