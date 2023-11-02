using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services;

public class Logger : IMYLogger
{
    private IList<Message> _messages;
    private IList<IAddressee> _addressees;

    public Logger()
    {
        _messages = new List<Message>();
        _addressees = new List<IAddressee>();
    }

    public void Log(Message message, IAddressee addressee)
    {
        _messages.Add(message);
        _addressees.Add(addressee);
    }

    public void ShowLogs()
    {
        for (int i = 0; i < _messages.Count; i++)
        {
            Console.WriteLine(_addressees[i].Name + " " + _messages[i].Render());
        }
    }
}