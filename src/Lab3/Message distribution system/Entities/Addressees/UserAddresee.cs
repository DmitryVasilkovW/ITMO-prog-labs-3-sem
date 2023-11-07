using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;

public class UserAddresee : IAddressee
{
    public UserAddresee(string name)
    {
        User = new User(name);
    }

    public User User { get; }

    public void GetMessage(Message message)
    {
        User.GetMessage(message);
    }
}