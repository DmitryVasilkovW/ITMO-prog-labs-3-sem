using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;

public class MessengerAdapter : IAddressee
{
    private IMYLogger _logger;

    public MessengerAdapter(string name)
    {
        Messenger = new Messenger(name);
        _logger = new Logger();
    }

    public Messenger Messenger { get; }

    public void GetMessage(Message message, LevelsOfImportance filter)
    {
        _logger.Log(message, Messenger);
        Messenger.GetMessage(message, filter);
    }
}