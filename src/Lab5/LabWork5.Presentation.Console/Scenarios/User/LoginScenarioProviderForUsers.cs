using System.Diagnostics.CodeAnalysis;
using LabWork5.Application.Contracts.Users;

namespace LabWork5.Presentation.Console.Scenarios.Login;

public class LoginScenarioProviderForUsers : ILoginScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;
    private readonly ScenarioRunner _scenarioProvider;

    public LoginScenarioProviderForUsers(
        IUserService service,
        ICurrentUserService currentUser,
        ScenarioRunner scenarioProvider)
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

        scenario = new LoginScenarioForUsers(_service, _scenarioProvider);
        return true;
    }
}