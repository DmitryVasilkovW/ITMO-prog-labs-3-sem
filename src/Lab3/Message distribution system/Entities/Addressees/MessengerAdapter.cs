using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;

public class MessengerAdapter : IAddressee
{
    private IAddressee _user;
    private IMYLogger _logger;

    public MessengerAdapter(string name)
    {
        _user = new Display(name);
        _logger = new Logger();
    }

    public void GetMessage(Message message, LevelsOfImportance filter)
    {
        _logger.Log(message, _user);
        _user.GetMessage(message, filter);
    }
}