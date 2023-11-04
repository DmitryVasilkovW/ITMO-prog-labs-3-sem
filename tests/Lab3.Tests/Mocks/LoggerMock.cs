using System;
using Itmo.ObjectOrientedProgramming.Lab2.MyException;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.IHaveName;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Lab3.Tests.Mocks;

public class LoggerMock : IConsoleLogger
{
    private Message? _message;
    private IAddressee? _addressee;
    public void Log(Message message, IAddressee addressee)
    {
        _message = message;
        _addressee = addressee;
        Console.WriteLine(((IName)addressee).Name + " " + message.Render());
    }

    public string CheckLogs()
    {
        if (_addressee is not null && _message is not null)
            return ((IName)_addressee).Name + " " + _message.Render();
        throw new ThePassedArgumentIsNullException();
    }
}