using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Lab3.Tests.Mocks;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Renderable;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class LoggingCheck : IEnumerable<object[]>
{
    public static IEnumerable<object[]> GetMessage
    {
        get
        {
            yield return new object[]
            {
                "241",
                "by @cyberronin",
                LevelsOfImportance.High,
            };
        }
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
    [MemberData(nameof(GetMessage), MemberType = typeof(LoggingCheck))]
    public void ComputerAssembly(
        string headline,
        string body,
        LevelsOfImportance importanceLevel)
    {
        var logger = new ConsoleLoggerMock();
        LevelsOfImportance filter = LevelsOfImportance.Low;
        Message message
            = new BaseMessageBuilder()
                .WithHeadline(new Text(headline)).WithBody(new Text(body))
                .WithLevelsOfImportance(importanceLevel).Build();
        var user = new UserAdapterMock("Telecaster525", logger, filter);
        var topic = new Topic("239");
        topic.Send(user, message);

        Assert.True(user.Checker("Telecaster525 241 by @cyberronin"));
    }
}