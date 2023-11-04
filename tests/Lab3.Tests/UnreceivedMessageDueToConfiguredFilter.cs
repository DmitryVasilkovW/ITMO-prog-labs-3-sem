using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Proxy;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Lab3.Tests.Mocks;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Renderable;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class UnreceivedMessageDueToConfiguredFilter : IEnumerable<object[]>
{
    public static IEnumerable<object[]> GetMessage
    {
        get
        {
            yield return new object[]
            {
                "241",
                "BY \n @GAYSHAMANIN \n @GAYSHAMANIN241 \n @MISHAGANIN \n @ITMO_MISHA \n @GISHAMANIN \n @MISHAGANIN241 \n @mishaganinchannel \n @GAYSHAMANIN239 \n And new: \n @itmo_giant_cock\n And not created @mishelganina",
                LevelsOfImportance.Low,
            };
        }
    }

    public static bool ResultsVerification(MessageSendingResult messagestatus, MessageSendingResult expectedValue)
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
    [MemberData(nameof(GetMessage), MemberType = typeof(UnreceivedMessageDueToConfiguredFilter))]
    public void ComputerAssembly(
        string headline,
        string body,
        LevelsOfImportance importanceLevel)
    {
        LevelsOfImportance filter = LevelsOfImportance.High;
        var user = new UserMock(filter);
        var proxy = new FilterProxy(user);
        Message message
            = new BaseMessageBuilder()
                .WithHeadline(new Text(headline)).WithBody(new Text(body))
                .WithLevelsOfImportance(importanceLevel).Build();
        var topic = new Topic("239");
        topic.Send(proxy, message);
        MessageSendingResult expectedValue = MessageSendingResult.Messagedidntgetthrough;
        MessageSendingResult messagesuatus = user.Checkresultofsending();

        Assert.True(ResultsVerification(expectedValue, messagesuatus));
    }
}