using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.IDraw;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.IHaveName;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Displays;

public class Display : ICanDraw, IName, IAddressee
{
    private Message? _message;
    private LevelsOfImportance _filter;

    public Display(string name, LevelsOfImportance filter)
    {
        Name = name;
        _filter = filter;
    }

    public string Name { get; }

    public void GetMessage(Message message)
    {
        if (_message is not null && _filter <= _message.ImportanceLevels)
            _message = message;
    }

    public void SetColor(ConsoleColor color)
    {
        if (_message is not null)
        {
            _message = new StyledMessageBuilder(color).Create(
                _message.Headline,
                _message.Body,
                _message.ImportanceLevels);
        }
    }

    public void DeleteMessage()
    {
        _message = null;
    }

    public void Draw()
    {
        if (_message is not null)
            Console.WriteLine(_message.Render());
    }
}