using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Displays;

public class Display : IAddressee
{
    private Message? _message;

    public Display(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void GetMessage(Message message, LevelsOfImportance filter)
    {
        if (_message is not null && filter != _message.ImportanceLevels)
            _message = message;
    }

    public void SetColor(ConsoleColor color)
    {
        if (_message is not null)
            _message = new StyledParagraphBuilder(color).Create(_message);
    }

    public void Deletemessage()
    {
        _message = null;
    }

    public void Draw()
    {
        Console.WriteLine(_message);
    }
}