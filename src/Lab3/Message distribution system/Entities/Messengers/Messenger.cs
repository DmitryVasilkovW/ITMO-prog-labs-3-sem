using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.IDraw;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.IHaveName;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Messengers;

public class Messenger : ICanDraw, IName, IAddressee, IHavefilter
{
    private PriorityQueue<Message, LevelsOfImportance> _messages;

    public Messenger(string name, LevelsOfImportance filter)
    {
        Name = name;
        _messages = new PriorityQueue<Message, LevelsOfImportance>();
        Filter = filter;
    }

    public string Name { get; }
    public LevelsOfImportance Filter { get; }
    public void GetMessage(Message message)
    {
        _messages.Enqueue(message, message.ImportanceLevels);
    }

    public void Draw()
    {
        Console.WriteLine(_messages.Dequeue().Render() + " Messenger");
    }
}