using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.IHaveName;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services;

public class ConsoleLogger : IConsoleLogger
{
    public void Log(Message message, IAddressee addressee)
    {
        Console.WriteLine(((IName)addressee).Name + " " + message.Render());
    }
}