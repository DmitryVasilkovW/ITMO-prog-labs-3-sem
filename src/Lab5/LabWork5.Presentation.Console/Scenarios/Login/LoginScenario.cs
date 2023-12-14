using LabWork5.Application.Contracts.Users;
using Spectre.Console;

namespace LabWork5.Presentation.Console.Scenarios.Login;

public class LoginScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginScenario(IUserService userService)
    {
        _userService = userService;
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
        AnsiConsole.Ask<string>("Ok");
    }
}