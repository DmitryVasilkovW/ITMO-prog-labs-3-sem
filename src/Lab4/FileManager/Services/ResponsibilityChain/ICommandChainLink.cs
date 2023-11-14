namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;

public interface ICommandChainLink
{
    void AddNext(ICommandChainLink link);

    void Handle(CommandRequest request);
}