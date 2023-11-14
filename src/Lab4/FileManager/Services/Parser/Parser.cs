using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;
namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Parser;

public class Parser
{
    private CommandChainLinkBase _chain;

    public Parser(CommandChainLinkBase chain)
    {
        _chain = chain;
    }

    public void Parse(string command)
    {
         _chain.Handle(new CommandRequest(command));
    }
}