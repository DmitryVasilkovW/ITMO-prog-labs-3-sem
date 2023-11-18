using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.TreeCommands;

public class TreeListCommand : ICommand
{
    private const int Initialdepth = 1;
    private int _depth = Initialdepth;
    private ICommandStrategy _strategy;
    private ICanPrint _printer;

    public TreeListCommand(ICommandStrategy strategy, ICanPrint printer)
    {
        _strategy = strategy;
        _printer = printer;
    }

    public void UpdateDepth(int depth)
    {
        _depth = depth;
    }

    public void Execute(ref string? path)
    {
        _strategy.TreeListCommand(_depth, _printer, ref path);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || GetType() != obj.GetType())
            return false;

        var command = (TreeListCommand)obj;
        return _depth == command._depth;
    }

    public override int GetHashCode()
    {
        return StringComparer.Ordinal.GetHashCode(_depth);
    }
}