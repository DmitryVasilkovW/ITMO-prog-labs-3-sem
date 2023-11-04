using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.DisplayDrivers;

public interface IDisplayDriver
{
    void ClearOutput();
    void AddColourModifier(ConsoleColor color);
    void Writetext(Message message);

    void Draw();
}