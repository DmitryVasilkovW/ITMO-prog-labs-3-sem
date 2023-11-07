using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services;

public class ConsoleLogger : ILogger
{
    public void Log(Message message)
    {
        Console.WriteLine(message.Render());
    }
}