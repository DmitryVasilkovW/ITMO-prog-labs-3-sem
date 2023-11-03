using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.IHaveName;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Mocks;

public class LoggerMock : IMYLogger
{
    private IList<IMessage> _messages;
    private IList<IName> _addressees;

    public LoggerMock()
    {
        _messages = new List<IMessage>();
        _addressees = new List<IName>();
    }

    public void Log(Message message, IName addressee)
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

    public string CheckLogs(int indexforchecker)
    {
        return _addressees[indexforchecker].Name + " " + _messages[indexforchecker].Render();
    }
}