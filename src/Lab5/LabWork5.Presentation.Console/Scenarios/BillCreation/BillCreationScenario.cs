using LabWork5.Application.Contracts.Users;
using Spectre.Console;

namespace LabWork5.Presentation.Console.Scenarios.BillCreation;

public class BillCreationScenario : IScenario
{
    private readonly IUserService _userService;

    public BillCreationScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Bill creation";

    public void Run()
    {
        long bill = AnsiConsole.Ask<long>("Enter your bill");

        _userService.BillCreation(bill);

        AnsiConsole.WriteLine("Ok");
    }
}