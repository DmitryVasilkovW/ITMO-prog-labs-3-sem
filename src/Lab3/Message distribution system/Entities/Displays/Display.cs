using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.IDraw;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.IHaveName;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Displays;

public class Display : ICanDraw, IName
{
    private Message? _message;

    public Display(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void GetMessage(Message message)
    {
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