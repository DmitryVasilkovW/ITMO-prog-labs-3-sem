using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

public class ConnectCommand : ICommand
{
    private string? _fullpath;
    private ICommandStrategy _strategy;
    public ConnectCommand(string fullpath, ICommandStrategy strategy)
    {
        _fullpath = fullpath;
        _strategy = strategy;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || GetType() != obj.GetType())
            return false;

        var command = (ConnectCommand)obj;
        return _fullpath == command._fullpath;
    }

    public override int GetHashCode()
    {
        return StringComparer.Ordinal.GetHashCode(_fullpath ?? string.Empty);
    }

    public void Execute(ref string? path)
    {
        _strategy.ConnectCommand(_fullpath, ref path);
    }
}