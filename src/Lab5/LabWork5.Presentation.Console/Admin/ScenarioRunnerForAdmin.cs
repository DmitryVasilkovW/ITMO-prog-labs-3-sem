using Spectre.Console;

namespace LabWork5.Presentation.Console.Admin;

public class ScenarioRunnerForAdmin
{
    private readonly IEnumerable<IScenarioProviderForAdmin> _providers;

    public ScenarioRunnerForAdmin(IEnumerable<IScenarioProviderForAdmin> providers)
    {
        _providers = providers;
    }

    public void Run()
    {
        IEnumerable<IScenarioForAdmin> scenarios = GetScenarios();

        SelectionPrompt<IScenarioForAdmin> selector = new SelectionPrompt<IScenarioForAdmin>()
            .Title("Select action")
            .AddChoices(scenarios)
            .UseConverter(x => x.Name);

        IScenarioForAdmin scenario = AnsiConsole.Prompt(selector);
        scenario.Run();
    }

    private IEnumerable<IScenarioForAdmin> GetScenarios()
    {
        foreach (IScenarioProviderForAdmin provider in _providers)
        {
            if (provider.TryGetScenario(out IScenarioForAdmin? scenario))
                yield return scenario;
        }
    }
}