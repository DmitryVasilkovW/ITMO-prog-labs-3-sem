using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Powersupplyunit.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Powersupplyunit.Entities;

public class PowerSupply : IPowerSupply, IPart
{
    public PowerSupply(string? name, int peakLoad)
    {
        Name = name;
        PeakLoad = peakLoad;
    }

    public int PeakLoad { get; init; }
    public string? Name { get; init; }
}