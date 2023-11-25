using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;

public class ConnectionRelatedHandle : CommandChainLinkBase
{
    private string _type = "connect disconnect";
    private IConcreteCommandChainLink _chain;

    public ConnectionRelatedHandle(IConcreteCommandChainLink chain)
    {
        _chain = chain;
    }

    public override ICommand? Handle(CommandRequest request)
    {
        if (request.Type().Equals(_type.TrimStart().Split(' ')[0], StringComparison.Ordinal)
            || request.Type().Equals(_type.TrimStart().Split(' ')[1], StringComparison.Ordinal))
        {
            string action = request.Command.TrimStart().Split(' ')[0];
            string parameters = string.Empty;

            for (int i = 1; i < request.Command.TrimStart().Split(' ').Length; i++)
            {
                parameters += request.Command.TrimStart().Split(' ')[i] + " ";
            }

            return _chain.Handle(new ConcreteCommandRequest(action, parameters, request.Strategy));
        }
        else
        {
            return Next?.Handle(request);
        }
    }
}