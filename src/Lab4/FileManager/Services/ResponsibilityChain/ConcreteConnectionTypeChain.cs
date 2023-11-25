using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;

public abstract class ConcreteConnectionTypeChain : IConcreteConnectionTypeChain
{
    protected IConcreteConnectionTypeChain? Next { get; private set; }

    public IConcreteConnectionTypeChain AddNext(IConcreteConnectionTypeChain link)
    {
        if (Next is null)
        {
            Next = link;
        }
        else
        {
            Next.AddNext(link);
        }

        return this;
    }

    public abstract ICommand? Handle(CommandRequest request);
}