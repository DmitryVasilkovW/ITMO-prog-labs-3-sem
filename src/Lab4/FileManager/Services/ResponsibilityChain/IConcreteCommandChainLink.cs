using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;

public interface IConcreteCommandChainLink
{
    IConcreteCommandChainLink AddNext(IConcreteCommandChainLink link);

    ICommand? Handle(ConcreteCommandRequest request);
}