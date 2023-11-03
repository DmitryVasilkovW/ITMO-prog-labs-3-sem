using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;

public class DisplayAdapter : IAddressee
{
    private IMYLogger _logger;

    public DisplayAdapter(string name)
    {
        Display = new Display(name);
        _logger = new Logger();
    }

    public Display Display { get; }

    public void GetMessage(Message message, LevelsOfImportance filter)
    {
        _logger.Log(message, Display);
        Display.GetMessage(message, filter);
    }
}