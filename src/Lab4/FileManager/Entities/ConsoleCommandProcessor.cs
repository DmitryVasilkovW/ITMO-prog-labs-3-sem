using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Entities;

public class ConsoleCommandProcessor : ICommandProcessor
{
    private IConcreteConnectionTypeChain _chain;
    private string? _fullpath;

    public ConsoleCommandProcessor(IConcreteConnectionTypeChain chain)
    {
        _chain = chain;
    }

    public void Processing()
    {
        string? request;
        while (!string.IsNullOrEmpty(request = Console.ReadLine()))
        {
            Console.WriteLine("Enter the command:");

            ICommand? command = null;

            if (request is not null)
            {
                command = new Parser(_chain).Parse(request);

                command?.Execute(ref _fullpath);
            }

            if (command is null)
            {
                Console.WriteLine("incorrect command:");
            }
        }
    }
}