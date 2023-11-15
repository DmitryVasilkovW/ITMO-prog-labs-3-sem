using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles.ConnectionRelated;

public class ConnectHandle : ConcreteCommandChainLinkBase
{
    private ICommand _command = new ConnectCommand();
    private string _action = "connect";

    public override void Handle(ConcreteCommandRequest request)
    {
        if (_action.Equals(request.Action, StringComparison.Ordinal))
        {
            _command.Execute();
        }
        else
        {
            Next?.Handle(request);
        }
    }
}