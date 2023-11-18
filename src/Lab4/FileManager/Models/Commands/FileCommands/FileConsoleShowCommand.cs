using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

public class FileConsoleShowCommand : ICommand
{
    private string _pathforFile;
    private ICommandStrategy _strategy;
    public FileConsoleShowCommand(string pathforFile, ICommandStrategy strategy)
    {
        _pathforFile = pathforFile;
        _strategy = strategy;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || GetType() != obj.GetType())
            return false;

        var command = (FileConsoleShowCommand)obj;
        return _pathforFile == command._pathforFile;
    }

    public override int GetHashCode()
    {
        return StringComparer.Ordinal.GetHashCode(_pathforFile);
    }

    public void Execute(ref string? path)
    {
        _strategy.FileConsoleShowCommand(_pathforFile, ref path);
    }
}