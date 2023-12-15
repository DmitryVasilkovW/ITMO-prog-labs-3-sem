using LabWork5.Presentation.Console.Admin;
using LabWork5.Presentation.Console.Admin.Scenarios.TransactionHistory;
using LabWork5.Presentation.Console.Scenarios.AccountFunding;
using LabWork5.Presentation.Console.Scenarios.BillCreation;
using LabWork5.Presentation.Console.Scenarios.Login;
using LabWork5.Presentation.Console.Scenarios.TransactionHistory;
using LabWork5.Presentation.Console.Scenarios.ViewBalance;
using LabWork5.Presentation.Console.Scenarios.Withdrawal;
using Microsoft.Extensions.DependencyInjection;

namespace LabWork5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<LoginScenarioRunner>();
        collection.AddScoped<ILoginScenarioProvider, LoginScenarioProviderForUsers>();
        collection.AddScoped<ILoginScenarioProvider, LoginScenarioProviderForAdmins>();

        collection.AddScoped<ScenarioRunner>();
        collection.AddScoped<IScenarioProvider, AccountFundingScenarioProvider>();
        collection.AddScoped<IScenarioProvider, BillCreationScenarioProvider>();
        collection.AddScoped<IScenarioProvider, TransactionHistoryScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ViewBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawalScenarioProvider>();
        collection.AddScoped<IScenarioProvider, TransactionHistoryScenarioProviderForAdmons>();

        return collection;
    }
}