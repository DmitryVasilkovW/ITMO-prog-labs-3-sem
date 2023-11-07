using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;

public class DisplayAddressee : IAddressee
{
    public DisplayAddressee(string name)
    {
        Display = new Display(name);
    }

    public Display Display { get; }

    public void GetMessage(Message message)
    {
        Display.GetMessage(message);
    }
}