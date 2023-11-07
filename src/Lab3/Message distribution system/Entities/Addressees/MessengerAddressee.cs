using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;

public class MessengerAddressee : IAddressee
{
    public MessengerAddressee(string name)
    {
        Messenger = new Messenger(name);
    }

    public Messenger Messenger { get; }

    public void GetMessage(Message message)
    {
        Messenger.GetMessage(message);
    }
}