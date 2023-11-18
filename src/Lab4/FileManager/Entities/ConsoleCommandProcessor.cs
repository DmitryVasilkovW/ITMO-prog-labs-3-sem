using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Entities;

public class ConsoleCommandProcessor : ICommandProcessor
{
    private IConcreteConnectionTypeChain _chain;
    private string? _fullpath;
    private string? _connectiontype;

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
                if (request.TrimStart().Split(' ').Contains("connect"))
                {
                    _connectiontype = request.TrimStart().Split(' ').Reverse().ToString();
                }
                else
                {
                    request += _connectiontype;
                }

                command = new Parser(_chain).Parse(request);

                command?.Execute(ref _fullpath);
            }
        }
    }
}