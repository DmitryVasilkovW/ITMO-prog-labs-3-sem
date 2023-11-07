using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Lab3.Tests.Mocks;

public class UserDecoratorMock : IAddressee
{
    private ConsoleLoggerMock _logger;

    public UserDecoratorMock(string name, ConsoleLoggerMock logger)
    {
        User = new User(name);
        _logger = logger;
    }

    public User User { get; }

    public void GetMessage(Message message)
    {
        _logger.Log(message);
        User.GetMessage(message);
    }

    public bool Checker(string result)
    {
        if (result.Equals(_logger.CheckLogs(), StringComparison.Ordinal))
        {
            return true;
        }

        return false;
    }
}