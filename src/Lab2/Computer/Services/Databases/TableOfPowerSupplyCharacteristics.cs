using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Powersupplyunit.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

public class TableOfPowerSupplyCharacteristics : IPartCharacteristics, IPowerSupply
{
    public TableOfPowerSupplyCharacteristics(string name, int peakLoad)
    {
        Name = name;
        PeakLoad = peakLoad;
    }

    public string? Name { get; init; }
    public int PeakLoad { get; init; }
}