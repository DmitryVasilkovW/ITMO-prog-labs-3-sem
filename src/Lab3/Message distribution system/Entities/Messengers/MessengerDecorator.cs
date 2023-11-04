using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;

public class MessengerDecorator : IAddressee
{
    private IConsoleLogger _logger;

    public MessengerDecorator(string name, IConsoleLogger logger, LevelsOfImportance filter)
    {
        Messenger = new Messenger(name, filter);
        _logger = logger;
    }

    public Messenger Messenger { get; }

    public void GetMessage(Message message)
    {
        _logger.Log(message, Messenger);
        Messenger.GetMessage(message);
    }
}