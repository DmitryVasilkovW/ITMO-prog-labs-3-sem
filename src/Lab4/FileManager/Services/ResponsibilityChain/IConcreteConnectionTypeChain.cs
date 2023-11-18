using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;

public interface IConcreteConnectionTypeChain
{
    IConcreteConnectionTypeChain AddNext(IConcreteConnectionTypeChain link);

    public abstract ICommand? Handle(CommandRequest request);
}