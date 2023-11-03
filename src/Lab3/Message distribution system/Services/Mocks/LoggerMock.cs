using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.IHaveName;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Mocks;

public class LoggerMock : IMYLogger
{
    private IList<Message> _messages;
    private IList<IAddressee> _addressees;

    public LoggerMock()
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
            Console.WriteLine(((IName)_addressees[i]).Name + " " + _messages[i].Render());
        }
    }

    public string CheckLogs(int indexforchecker)
    {
        return ((IName)_addressees[indexforchecker]).Name + " " + _messages[indexforchecker].Render();
    }
}