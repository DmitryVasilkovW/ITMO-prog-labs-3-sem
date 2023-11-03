using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.IDraw;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.IHaveName;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Mocks;

public class MessengerMock : IAddressee, ICanDraw, IName
{
    private PriorityQueue<Message, LevelsOfImportance> _messages;

    public MessengerMock(string name)
    {
        Name = name;
        _messages = new PriorityQueue<Message, LevelsOfImportance>();
    }

    public string Name { get; }
    public void GetMessage(Message message, LevelsOfImportance filter)
    {
        if (filter != message.ImportanceLevels)
            _messages.Enqueue(message, message.ImportanceLevels);
    }

    public void Draw()
    {
        Console.WriteLine(_messages.Dequeue().Render() + " Messenger");
    }

    public string CheckDraw()
    {
        return _messages.Dequeue().Render() + " Messenger";
    }
}