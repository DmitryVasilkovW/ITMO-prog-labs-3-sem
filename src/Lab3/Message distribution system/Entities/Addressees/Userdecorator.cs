using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;

public class Userdecorator : IAddressee
{
    private IConsoleLogger _logger;

    public Userdecorator(string name, LevelsOfImportance filter, IConsoleLogger logger)
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
}