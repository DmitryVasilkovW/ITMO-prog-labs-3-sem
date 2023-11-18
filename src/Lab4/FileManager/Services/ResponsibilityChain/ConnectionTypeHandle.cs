using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;

public class ConnectionTypeHandle : ConcreteConnectionTypeChain
{
    private string _type = "local";
    private ICommandChainLink _chain;

    public ConnectionTypeHandle(ICommandChainLink chain)
    {
        _chain = chain;
    }

    public override ICommand? Handle(CommandRequest request)
    {
        if (CommandRequest.ConnectionMode is not null && CommandRequest.ConnectionMode.Equals(_type, StringComparison.Ordinal))
        {
            request.Updatetrategy(new LocalFileCommands());
            return _chain.Handle(request);
        }
        else
        {
            return Next?.Handle(request);
        }
    }
}