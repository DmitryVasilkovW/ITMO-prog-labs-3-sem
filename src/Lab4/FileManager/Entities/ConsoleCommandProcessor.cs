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
        while (!string.IsNullOrEmpty(Console.ReadLine()))
        {
            Console.WriteLine("Enter the command:");
            string? request = Console.ReadLine();

            ICommand? command;

            if (request is not null)
            {
                command = new Parser(_chain).Parse(request);

                command?.Execute(ref _fullpath);
            }
            else
            {
                Console.WriteLine("incorrect command:");
            }
        }
    }
}