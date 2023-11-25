using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles.ConnectionRelated;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles.TreeHandles;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services;

public static class Programm
{
    public static void Main()
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

        var prog = new ConsoleCommandProcessor(chain);
        prog.Processing();
    }
}