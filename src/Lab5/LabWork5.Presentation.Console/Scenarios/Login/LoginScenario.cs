using LabWork5.Application.Contracts.Users;
using Spectre.Console;

namespace LabWork5.Presentation.Console.Scenarios.Login;

public class LoginScenario : ILoginOptionScenario
{
    private readonly IUserService _userService;
    private readonly ScenarioRunner _scenarioRunner;

    public LoginScenario(IUserService userService, ScenarioRunner scenarioRunner)
    {
        _userService = userService;
        _scenarioRunner = scenarioRunner;
    }

    public string Name => "Login";

    public void Run()
    {
        long bill = AnsiConsole.Ask<long>("Enter your bill");

        LoginResult result = _userService.Login(bill);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.NotFound => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };
        AnsiConsole.WriteLine(message);

        while (true)
        {
            _scenarioRunner.Run();
        }
    }
}