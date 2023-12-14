using LabWork5.Presentation.Console.Scenarios.Login;
using Microsoft.Extensions.DependencyInjection;

namespace LabWork5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();

        return collection;
    }
}