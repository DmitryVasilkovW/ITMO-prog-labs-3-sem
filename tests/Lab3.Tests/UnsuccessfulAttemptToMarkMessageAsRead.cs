using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Renderable;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class UnsuccessfulAttemptToMarkMessageAsRead : IEnumerable<object[]>
{
    public static IEnumerable<object[]> GetShips
    {
        get
        {
            yield return new object[]
            {
                "239",
                "by @EMINBEGIN",
                LevelsOfImportance.High,
            };
        }
    }

    public static bool ResultsVerification(MessageStatusChangeResults messagestatus, MessageStatusChangeResults expectedValue)
    {
        if (messagestatus == expectedValue)
        {
            return true;
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
    [MemberData(nameof(GetShips), MemberType = typeof(SuccessfulAttemptToMarkMessageAsRead))]
    public void ComputerAssembly(
        string headline,
        string body,
        LevelsOfImportance importanceLevel)
    {
        Message message
            = new BaseMessageBuilder()
                .WithHeadline(new Text(headline)).WithBody(new Text(body))
                .WithLevelsOfImportance(importanceLevel).Build();

        var user = new User("Rafic");
        var topic = new Topic("LC");

        topic.Send(user, message, LevelsOfImportance.Low);
        MessageStatusChangeResults messagestatus;
        _ = user.MarkMessageAsRead(message);
        messagestatus = user.MarkMessageAsRead(message);
        MessageStatusChangeResults expectedValue = MessageStatusChangeResults.CannotChangeMessageStatus;

        Assert.True(ResultsVerification(messagestatus, expectedValue));
    }
}