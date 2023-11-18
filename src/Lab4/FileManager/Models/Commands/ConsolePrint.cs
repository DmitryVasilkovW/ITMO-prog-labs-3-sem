using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

public class ConsolePrint : ICanPrint
{
    public void Print(string printable)
    {
        Console.WriteLine(printable);
    }
}