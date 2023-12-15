using System.Diagnostics.CodeAnalysis;

namespace LabWork5.Presentation.Console.Admin;

public interface IScenarioProviderForAdmin
{
    bool TryGetScenario([NotNullWhen(true)] out IScenarioForAdmin? scenario);
}