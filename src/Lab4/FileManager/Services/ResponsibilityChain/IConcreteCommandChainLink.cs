namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;

public interface IConcreteCommandChainLink
{
    IConcreteCommandChainLink AddNext(IConcreteCommandChainLink link);

    void Handle(ConcreteCommandRequest request);
}