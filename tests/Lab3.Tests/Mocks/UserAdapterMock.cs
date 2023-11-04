using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Lab3.Tests.Mocks;

public class UserAdapterMock : IAddressee
{
    private LoggerMock _logger;

    public UserAdapterMock(string name, LoggerMock logger, LevelsOfImportance filter)
    {
        User = new User(name, filter);
        _logger = logger;
    }

    public User User { get; }

    public void GetMessage(Message message)
    {
        _logger.Log(message, User);
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