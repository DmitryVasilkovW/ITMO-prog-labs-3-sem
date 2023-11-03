using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Mocks;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Renderable;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class CheckingTheOperationOfTheMessenger : IEnumerable<object[]>
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

    IEnumerator<object[]> IEnumerable<object[]>.GetEnumerator()
    {
        throw new IncorrectNumberOfArgumentsException();
    }

    public IEnumerator GetEnumerator()
    {
        return GetEnumerator();
    }

    [Theory]
    [MemberData(nameof(GetShips), MemberType = typeof(Checkingthestatusofamessagewhenitisreceived))]
    public void ComputerAssembly(
        string headline,
        string body,
        LevelsOfImportance importanceLevel)
    {
        Message message
            = new BaseMessageBuilder()
                .WithHeadline(new Text(headline)).WithBody(new Text(body))
                .WithLevelsOfImportance(importanceLevel).Build();
        var messenger = new MessengerMock("Rafic");
        var topic = new Topic("LC");
        topic.Send(messenger, message, LevelsOfImportance.Low);
        string result = messenger.CheckDraw();
        string expectedValue = "239by @EMINBEGIN Messenger";

        Assert.Equal(result, expectedValue);
    }
}