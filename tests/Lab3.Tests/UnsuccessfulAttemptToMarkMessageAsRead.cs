using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Renderable;
using Itmo.ObjectOrientedProgramming.Lab3.MyException;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class UnsuccessfulAttemptToMarkMessageAsRead : IEnumerable<object[]>
{
    public static IEnumerable<object[]> GetMessage
    {
        get
        {
            yield return new object[]
            {
                "239",
                "by @mishaganin",
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
    [MemberData(nameof(GetMessage), MemberType = typeof(SuccessfulAttemptToMarkMessageAsRead))]
    public void ComputerAssembly(
        string headline,
        string body,
        LevelsOfImportance importanceLevel)
    {
        Message message
            = new BaseMessageBuilder()
                .WithHeadline(new Text(headline)).WithBody(new Text(body))
                .WithLevelsOfImportance(importanceLevel).Build();

        var user = new UserAddresee("Telecaster525");
        var topic = new Topic("239");

        topic.Send(user, message);
        MessageStatusChangeResults messagestatus;
        _ = user.User.MarkMessageAsRead(message);
        messagestatus = user.User.MarkMessageAsRead(message);
        MessageStatusChangeResults expectedValue = MessageStatusChangeResults.CannotChangeMessageStatus;

        Assert.True(ResultsVerification(messagestatus, expectedValue));
    }
}