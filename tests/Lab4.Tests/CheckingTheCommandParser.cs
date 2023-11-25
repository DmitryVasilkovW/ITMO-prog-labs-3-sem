using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles.ConnectionRelated;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles.TreeHandles;
using Itmo.ObjectOrientedProgramming.Lab4.MyException;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class CheckingTheCommandParser : IEnumerable<object[]>
{
    public static IEnumerable<object[]> GetCommands
    {
        get
        {
            yield return new object[]
        {
            "connect /Users/dmitryvasilkov/Desktop/qwe -m local",
            "file show /Users/dmitryvasilkov/Desktop/qwe -m console",
        };
        }
    }

    public static bool ResultsVerification(ICommand expectedvalue, ICommand? result)
    {
        if (expectedvalue.Equals(result))
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
    [MemberData(nameof(GetCommands), MemberType = typeof(CheckingTheCommandParser))]
    public void ComputerAssembly(
        string firstcommand,
        string secondcommand)
    {
        IConcreteCommandChainLink connectionrelatedchain =
            new ConnectHandle().
                AddNext(new DisconnectHandle());

        IConcreteCommandChainLink filechain =
            new CopyFileHandle().
                AddNext(new DeleteFileHandle().
                    AddNext(new MoveFileHandle().
                        AddNext(new RenameFileHandle().
                            AddNext(new ShowFileHandle()))));

        IConcreteCommandChainLink treechain =
            new GotoTreeHandle().
                AddNext(new ListTreeHandle());

        ICommandChainLink commandchain =
            new ConnectionRelatedHandle(connectionrelatedchain).
                AddNext(new FileHandle(filechain).
                    AddNext(new TreeHandle(treechain)));

        IConcreteConnectionTypeChain chain = new ConnectionTypeHandle(commandchain);

        var parser = new Parser(chain);
        var firstexpectedcommand = new ConnectCommand("/Users/dmitryvasilkov/Desktop/qwe", new LocalFileCommands());
        ICommand? firstcommandresult = parser.Parse(firstcommand);
        var secondexpectedcommand = new FileConsoleShowCommand("/Users/dmitryvasilkov/Desktop/qwe", new LocalFileCommands());
        ICommand? secondcommandresult = parser.Parse(secondcommand);

        Assert.True(ResultsVerification(firstexpectedcommand, firstcommandresult));
        Assert.True(ResultsVerification(secondexpectedcommand, secondcommandresult));
    }
}