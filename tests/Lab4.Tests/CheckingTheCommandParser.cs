using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.TreeCommands;
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
            "tree list -d 2",
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
    [MemberData(nameof(GetCommands), MemberType = typeof(CheckingTheCommandParser))]
    public void ComputerAssembly(
        string firstcommand,
        string secondcommand,
        string thirdcommand)
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

        ICommandChainLink chain =
            new ConnectionRelatedHandle(connectionrelatedchain).
                AddNext(new FileHandle(filechain).
                    AddNext(new TreeHandle(treechain)));

        var parser = new Parser(chain);

        Assert.True(parser.Parse(firstcommand) is ConnectCommand);
        Assert.True(parser.Parse(secondcommand) is FileConsoleShowCommand);
        Assert.True(parser.Parse(thirdcommand) is TreeListCommand);
    }
}