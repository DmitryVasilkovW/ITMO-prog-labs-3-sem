using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;

public class DisplayDecorator : IAddressee
{
    private IConsoleLogger _logger;

    public DisplayDecorator(string name, IConsoleLogger logger, LevelsOfImportance filter)
    {
        Display = new Display(name, filter);
        _logger = logger;
    }

    public Display Display { get; }

    public void GetMessage(Message message)
    {
        _logger.Log(message, Display);
        Display.GetMessage(message);
    }
}