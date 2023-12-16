using System.Diagnostics.CodeAnalysis;

namespace LabWork5.Presentation.Console;

public interface IScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}