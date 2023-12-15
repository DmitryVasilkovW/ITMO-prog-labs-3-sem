using LabWork5.Application.Contracts.Admins;
using LabWork5.Application.Contracts.Users;
using LabWork5.Presentation.Console.Scenarios.Login;
using Spectre.Console;

namespace LabWork5.Presentation.Console.Admin;

public class LoginScenarioForAdmins : ILoginOptionScenario
{
    private readonly IAdminService _adminService;
    private readonly ScenarioRunnerForAdmin _scenarioRunner;

    public LoginScenarioForAdmins(IAdminService adminService, ScenarioRunnerForAdmin scenarioRunner)
    {
        _adminService = adminService;
        _scenarioRunner = scenarioRunner;
    }

    public string Name => "Login as admin";

    public void Run()
    {
        string password = AnsiConsole.Ask<string>("Enter the administrator password");

        LoginResult result = _adminService.Login(password);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.NotFound => "incorrect password",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };
        AnsiConsole.WriteLine(message);

        while (true)
        {
            _scenarioRunner.Run();
        }
    }
}