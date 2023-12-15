using LabWork5.Application.Contracts.Users;
using Spectre.Console;

namespace LabWork5.Presentation.Console.Scenarios.Login;

public class LoginScenarioForUsers : ILoginOptionScenario
{
    private readonly IUserService _userService;
    private readonly ScenarioRunner _scenarioRunner;

    public LoginScenarioForUsers(IUserService userService, ScenarioRunner scenarioRunner)
    {
        _userService = userService;
        _scenarioRunner = scenarioRunner;
    }

    public string Name => "Login as user";

    public void Run()
    {
        long bill = AnsiConsole.Ask<long>("Enter your bill");
        string password = AnsiConsole.Ask<string>("Enter your password");

        LoginResult result = _userService.Login(bill, password);

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