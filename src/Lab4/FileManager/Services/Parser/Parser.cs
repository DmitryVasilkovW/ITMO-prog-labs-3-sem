using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;
namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Parser;

public class Parser
{
    private IConcreteConnectionTypeChain _chain;

    public Parser(IConcreteConnectionTypeChain chain)
    {
        _chain = chain;
    }

    public ICommand? Parse(string command)
    {
         return _chain.Handle(new CommandRequest(command));
    }
}