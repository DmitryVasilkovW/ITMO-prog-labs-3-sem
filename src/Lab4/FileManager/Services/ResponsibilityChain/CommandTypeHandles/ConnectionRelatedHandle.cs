using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.Handles;

public class ConnectionRelatedHandle : CommandChainLinkBase
{
    private string _type = "connect disconnect";
    private IConcreteCommandChainLink _chain;

    public ConnectionRelatedHandle(IConcreteCommandChainLink chain)
    {
        _chain = chain;
    }

    public override void Handle(CommandRequest request)
    {
        if (request.Type().Equals(_type.TrimStart().Split(' ')[0], StringComparison.Ordinal)
            || request.Type().Equals(_type.TrimStart().Split(' ')[1], StringComparison.Ordinal))
        {
            string action = request.Command.TrimStart().Split(' ')[1];
            string parameters = string.Empty;

            for (int i = 2; i < request.Command.TrimStart().Split(' ').Length; i++)
            {
                parameters += request.Command.TrimStart().Split(' ')[i] + " ";
            }

            _chain.Handle(new ConcreteCommandRequest(action, parameters));
        }
        else
        {
            Next?.Handle(request);
        }
    }
}