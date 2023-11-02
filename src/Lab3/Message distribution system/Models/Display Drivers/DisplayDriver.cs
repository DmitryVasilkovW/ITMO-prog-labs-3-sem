using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.DisplayDrivers;

public class DisplayDriver : IDisplayDriver
{
    private Display _display;

    public DisplayDriver(string name)
    {
        _display = new Display(name);
    }

    public void ClearOutput()
    {
        _display.Deletemessage();
    }

    public void AddColourModifier()
    {
    }

    public void Writetext(Message message, LevelsOfImportance filter)
    {
        ClearOutput();
        _display.GetMessage(message, filter);
    }

    public void Draw()
    {
        _display.Draw();
    }
}