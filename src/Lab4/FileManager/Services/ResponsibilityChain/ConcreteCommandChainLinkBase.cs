using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services;

public abstract class ConcreteCommandChainLinkBase : IConcreteCommandChainLink
{
    protected IConcreteCommandChainLink? Next { get; private set; }

    public IConcreteCommandChainLink AddNext(IConcreteCommandChainLink link)
    {
        if (Next is null)
        {
            Next = link;
        }
        else
        {
            Next.AddNext(link);
        }

        return Next;
    }

    public abstract void Handle(ConcreteCommandRequest request);
}