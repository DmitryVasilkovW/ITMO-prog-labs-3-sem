using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;

public interface ICommandChainLink
{
    ICommandChainLink AddNext(ICommandChainLink link);

    ICommand? Handle(CommandRequest request);
}