using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;

public abstract class CommandChainLinkBase : ICommandChainLink
{
    protected ICommandChainLink? Next { get; private set; }

    public ICommandChainLink AddNext(ICommandChainLink link)
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