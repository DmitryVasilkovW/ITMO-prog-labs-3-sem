using System.Globalization;
using LabWork5.Application.Contracts.Users;
using Spectre.Console;

namespace LabWork5.Presentation.Console.Scenarios.ViewBalance;

public class ViewBalanceScenario : IScenario
{
    private readonly IUserService _userService;

    public ViewBalanceScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "View balance";

    public void Run()
    {
        long bill = AnsiConsole.Ask<long>("Enter your bill");

        long result = _userService.ViewBalance(bill);

        AnsiConsole.WriteLine(CultureInfo.InvariantCulture, "{0}", result);
        AnsiConsole.WriteLine("Ok");
    }
}