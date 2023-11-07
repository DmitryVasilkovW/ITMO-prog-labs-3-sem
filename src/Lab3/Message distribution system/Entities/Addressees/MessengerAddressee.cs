using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;

public class MessengerAddressee : IAddressee
{
    private Messenger _messenger;

    public MessengerAddressee(string name)
    {
        _messenger = new Messenger(name);
    }

    public void GetMessage(Message message)
    {
        _messenger.GetMessage(message);
    }
}