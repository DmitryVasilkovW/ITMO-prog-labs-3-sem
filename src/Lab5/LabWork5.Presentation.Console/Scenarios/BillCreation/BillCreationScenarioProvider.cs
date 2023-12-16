using System.Diagnostics.CodeAnalysis;
using LabWork5.Application.Contracts.Users;

namespace LabWork5.Presentation.Console.Scenarios.BillCreation;

public class BillCreationScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public BillCreationScenarioProvider(
        IUserService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new BillCreationScenario(_service);
        return true;
    }
}