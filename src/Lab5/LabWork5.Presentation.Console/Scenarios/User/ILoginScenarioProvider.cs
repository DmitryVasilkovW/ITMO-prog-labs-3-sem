using System.Diagnostics.CodeAnalysis;
using LabWork5.Presentation.Console.Scenarios.Login;

namespace LabWork5.Presentation.Console;

public interface ILoginScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out ILoginOptionScenario? scenario);
}