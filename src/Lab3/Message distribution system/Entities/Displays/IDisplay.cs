using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Displays;

public interface IDisplay
{
    void GetMessage(Message message);
    void SetColor(ConsoleColor color);
    public void DeleteMessage();
}