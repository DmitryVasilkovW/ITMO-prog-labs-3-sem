using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Renderable;
using Itmo.ObjectOrientedProgramming.Lab3.MyException;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Checkingthestatusofamessagewhenitisreceived : IEnumerable<object[]>
{
    public static IEnumerable<object[]> GetMessage
    {
        get
        {
            yield return new object[]
        {
            "239",
            "by @bloom_guy",
            LevelsOfImportance.High,
        };
        }
    }

    public static bool ResultsVerification(User user, Message sentmessage)
    {
        foreach (Message message in ((User)user).Messagestatuses[(int)MessageStatus.Unread])
        {
            if (message.Equals(sentmessage))
            {
                return true;
            }
        }

        return false;
    }

    IEnumerator<object[]> IEnumerable<object[]>.GetEnumerator()
    {
        throw new IncorrectNumberOfArgumentsException();
    }

    public IEnumerator GetEnumerator()
    {
        return GetEnumerator();
    }

    [Theory]
    [MemberData(nameof(GetMessage), MemberType = typeof(Checkingthestatusofamessagewhenitisreceived))]
    public void ComputerAssembly(
        string headline,
        string body,
        LevelsOfImportance importanceLevel)
    {
        var logger = new ConsoleLogger();
        var user = new UserAddresee("Name");
        Message message
            = new BaseMessageBuilder()
            .WithHeadline(new Text(headline)).WithBody(new Text(body))
            .WithLevelsOfImportance(importanceLevel).Build();
        var userdecorator = new AddresseeLogDecorator(logger, user);
        var topic = new Topic("239");
        topic.Send(userdecorator, message);

        Assert.True(ResultsVerification(user.User, message));
    }
}