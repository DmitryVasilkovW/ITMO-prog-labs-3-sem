using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Entities;

public class ConsoleCommandProcessor
{
    private ICommandChainLink _chain;
    private string? _fullpath;

    public ConsoleCommandProcessor(ICommandChainLink chain)
    {
        _chain = chain;
    }

    public void Processing()
    {
        Console.WriteLine("Enter the command:");
        string? request = Console.ReadLine();

        ICommand? command;

        if (request is not null)
        {
            command = new Parser(_chain).Parse(request);

            if (command is ICommandRelatedToChangingFullPath)
            {
                _fullpath = ((ICommandRelatedToChangingFullPath)command).Fullpath;
            }
            else if (command is IDependsOnFullPath)
            {
                if (_fullpath is not null) ((IDependsOnFullPath)command).UpdateFullpath(_fullpath);
            }

            command?.Execute();
        }
    }
}