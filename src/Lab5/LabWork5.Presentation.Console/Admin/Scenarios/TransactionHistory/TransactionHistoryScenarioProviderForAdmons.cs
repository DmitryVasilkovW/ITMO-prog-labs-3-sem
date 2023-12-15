using System.Diagnostics.CodeAnalysis;
using LabWork5.Application.Contracts.Admins;

namespace LabWork5.Presentation.Console.Admin.Scenarios.TransactionHistory;

public class TransactionHistoryScenarioProviderForAdmons : IScenarioProviderForAdmin
{
    private readonly IAdminService _service;

    public TransactionHistoryScenarioProviderForAdmons(
        IAdminService service)
    {
        _service = service;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenarioForAdmin? scenario)
    {
        scenario = new TransactionHistoryScenarioForAdmins(_service);
        return true;
    }
}