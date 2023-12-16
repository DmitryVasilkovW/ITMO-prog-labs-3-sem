using LabWork5.Application.Contracts.Users;
using Spectre.Console;

namespace LabWork5.Presentation.Console.Scenarios.AccountFunding;

public class AccountFundingScenario : IScenario
{
    private readonly IUserService _userService;

    public AccountFundingScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Account funding";

    public void Run()
    {
        long bill = AnsiConsole.Ask<long>("Enter your bill");
        long depositmoney = AnsiConsole.Ask<long>("Enter your depositmoney");

        _userService.AccountFunding(bill, depositmoney);

        AnsiConsole.WriteLine("Ok");
    }
}