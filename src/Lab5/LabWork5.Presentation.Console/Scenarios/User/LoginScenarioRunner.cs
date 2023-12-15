using LabWork5.Presentation.Console.Scenarios.Login;
using Spectre.Console;

namespace LabWork5.Presentation.Console;

public class LoginScenarioRunner
{
    private readonly IEnumerable<ILoginScenarioProvider> _providers;

    public LoginScenarioRunner(IEnumerable<ILoginScenarioProvider> providers)
    {
        _providers = providers;
    }

    public void Run()
    {
        IEnumerable<ILoginOptionScenario> scenarios = GetScenarios();

        SelectionPrompt<ILoginOptionScenario> selector = new SelectionPrompt<ILoginOptionScenario>()
            .Title("Select action")
            .AddChoices(scenarios)
            .UseConverter(x => x.Name);

        ILoginOptionScenario scenario = AnsiConsole.Prompt(selector);
        scenario.Run();
    }

    private IEnumerable<ILoginOptionScenario> GetScenarios()
    {
        foreach (ILoginScenarioProvider provider in _providers)
        {
            if (provider.TryGetScenario(out ILoginOptionScenario? scenario))
                yield return scenario;
        }
    }
}