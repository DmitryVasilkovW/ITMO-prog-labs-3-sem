using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Lab3.Tests.Mocks;

public class UserAddresseeMock : IAddressee
{
    public UserAddresseeMock()
    {
        User = new UserMock();
    }

    public UserMock User { get; }

    public void GetMessage(Message message)
    {
        User.GetMessage(message);
    }
}