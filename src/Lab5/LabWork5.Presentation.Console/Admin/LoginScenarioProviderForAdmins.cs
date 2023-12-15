using System.Diagnostics.CodeAnalysis;
using LabWork5.Application.Contracts.Admins;
using LabWork5.Application.Contracts.Users;
using LabWork5.Presentation.Console.Scenarios.Login;

namespace LabWork5.Presentation.Console.Admin;

public class LoginScenarioProviderForAdmins : ILoginScenarioProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentUserService _currentUser;
    private readonly ScenarioRunnerForAdmin _scenarioProvider;

    public LoginScenarioProviderForAdmins(
        IAdminService service,
        ICurrentUserService currentUser,
        ScenarioRunnerForAdmin scenarioProvider)
    {
        _service = service;
        _currentUser = currentUser;
        _scenarioProvider = scenarioProvider;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out ILoginOptionScenario? scenario)
    {
        if (_currentUser.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new LoginScenarioForAdmins(_service, _scenarioProvider);
        return true;
    }
}