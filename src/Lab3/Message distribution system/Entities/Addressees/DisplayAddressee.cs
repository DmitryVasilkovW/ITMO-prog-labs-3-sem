using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;

public class DisplayAddressee : IAddressee
{
    private Display _display;

    public DisplayAddressee(string name)
    {
        _display = new Display(name);
    }

    public void GetMessage(Message message)
    {
        _display.GetMessage(message);
    }
}