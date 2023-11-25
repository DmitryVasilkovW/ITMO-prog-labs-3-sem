using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;
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

        return this;
    }

    public abstract ICommand? Handle(ConcreteCommandRequest request);
}