using LabWork5.Application.Contracts.Admins;
using Spectre.Console;

namespace LabWork5.Presentation.Console.Admin.Scenarios.TransactionHistory;

public class TransactionHistoryScenarioForAdmins : IScenario
{
    private readonly IAdminService _adminService;

    public TransactionHistoryScenarioForAdmins(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Transaction History";

    public void Run()
    {
        long userid = AnsiConsole.Ask<long>("Enter user_id");

        IList<string>? result = _adminService.TransactionHistory(userid);

        if (result is not null)
        {
            foreach (string operation in result)
            {
                AnsiConsole.WriteLine(operation);
            }
        }

        AnsiConsole.WriteLine("Ok");
    }
}