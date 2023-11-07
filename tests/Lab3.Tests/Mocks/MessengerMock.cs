using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.IDraw;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.IHaveName;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Lab3.Tests.Mocks;

public class MessengerMock : IAddressee, ICanDraw, IName
{
    private PriorityQueue<Message, LevelsOfImportance> _messages;
    private LevelsOfImportance _filter;

    public MessengerMock(string name, LevelsOfImportance filter)
    {
        Name = name;
        _messages = new PriorityQueue<Message, LevelsOfImportance>();
        _filter = filter;
    }

    public string Name { get; }
    public void GetMessage(Message message)
    {
        if (_filter != message.ImportanceLevels)
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