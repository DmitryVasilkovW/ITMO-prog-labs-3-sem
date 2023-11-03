using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Mocks;

public class UserAdapterMock : IAddressee
{
    private LoggerMock _logger;

    public UserAdapterMock(string name)
    {
        User = new User(name);
        _logger = new LoggerMock();
    }

    public User User { get; }

    public void GetMessage(Message message, LevelsOfImportance filter)
    {
        _logger.Log(message, User);
        User.GetMessage(message, filter);
    }

    public bool Checker(string result)
    {
        if (result.Equals(_logger.CheckLogs(0), StringComparison.Ordinal))
        {
            return true;
        }

        return false;
    }
}