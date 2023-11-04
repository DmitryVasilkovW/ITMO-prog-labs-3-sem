using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.IHaveName;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services;

public class ConsoleLogger : IConsoleLogger
{
    private IList<Message> _messages;
    private IList<IAddressee> _addressees;

    public ConsoleLogger()
    {
        _messages = new List<Message>();
        _addressees = new List<IAddressee>();
    }

    public void Log(Message message, IAddressee addressee)
    {
        Console.WriteLine(((IName)addressee).Name + " " + message.Render());
    }
}