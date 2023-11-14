namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;

public abstract class CommandChainLinkBase : ICommandChainLink
{
    protected ICommandChainLink? Next { get; private set; }

    public void AddNext(ICommandChainLink link)
    {
        if (Next is null)
        {
            Next = link;
        }
        else
        {
            Next.AddNext(link);
        }
    }

    public abstract void Handle(CommandRequest request);
}