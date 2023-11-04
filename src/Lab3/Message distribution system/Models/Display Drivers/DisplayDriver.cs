using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.DisplayDrivers;

public class DisplayDriver : IDisplayDriver
{
    private Display _display;

    public DisplayDriver(string name, LevelsOfImportance filter)
    {
        _display = new Display(name, filter);
    }

    public void ClearOutput()
    {
        _display.DeleteMessage();
    }

    public void AddColourModifier(ConsoleColor color)
    {
        _display.SetColor(color);
    }

    public void Writetext(Message message)
    {
        ClearOutput();
        _display.GetMessage(message);
    }

    public void Draw()
    {
        _display.Draw();
    }
}