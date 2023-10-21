using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Powersupplyunit.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Prototype;
using Itmo.ObjectOrientedProgramming.Lab2.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Powersupplyunit.Entities;

public class PowerSupply : IPowerSupply, IPart, IPrototype<PowerSupply>
{
    public PowerSupply(string? name, int peakLoad)
    {
        Name = name;
        PeakLoad = peakLoad;
    }

    public int PeakLoad { get; private set; }
    public string? Name { get; private set; }
    public PowerSupply Clone()
    {
        if (Name is not null)
        {
            return new PowerSupply(
                (string)Name.Clone(),
                PeakLoad);
        }

        throw new ThePassedArgumentIsNullException();
    }

    public PowerSupply SetPeakLoad(int newPeakLoad)
    {
        PowerSupply clone = Clone();

        clone.PeakLoad = newPeakLoad;

        return clone;
    }

    public PowerSupply SetName(string? newName)
    {
        PowerSupply clone = Clone();

        clone.Name = newName;

        return clone;
    }
}