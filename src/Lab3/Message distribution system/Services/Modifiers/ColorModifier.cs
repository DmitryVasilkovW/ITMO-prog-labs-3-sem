using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Renderable;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Modifiers;

public class ColorModifier : IRenderableModifier
{
    private readonly ConsoleColor _consoleColor;

    public ColorModifier(ConsoleColor consoleColor)
    {
        _consoleColor = consoleColor;
    }

    public string? Modify(string? value)
    {
        switch (_consoleColor)
        {
            case ConsoleColor.Black:
                Console.BackgroundColor = ConsoleColor.White;
                break;

            default:
                Console.BackgroundColor = ConsoleColor.Black;
                break;
        }

        Console.ForegroundColor = _consoleColor;
        Console.WriteLine(value);
        Console.ResetColor();

        return value;
    }
}
