using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Lab3.Tests.Mocks;

public class ConsoleLoggerMock : ILogger
{
    private Message? _message;
    public void Log(Message message)
    {
        _message = message;
        Console.WriteLine(message.Render());
    }

    public string? CheckLogs()
    {
        if (_message is not null)
            return _message.Render();
        throw new ThePassedArgumentIsNullException();
    }
}