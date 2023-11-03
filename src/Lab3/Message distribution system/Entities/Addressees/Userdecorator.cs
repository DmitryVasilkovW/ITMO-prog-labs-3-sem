using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;

public class Userdecorator : IAddressee
{
    private IMYLogger _logger;

    public Userdecorator(string name)
    {
        User = new User(name);
        _logger = new Logger();
    }

    public User User { get; }

    public void GetMessage(Message message, LevelsOfImportance filter)
    {
        _logger.Log(message, User);
        User.GetMessage(message, filter);
    }
}