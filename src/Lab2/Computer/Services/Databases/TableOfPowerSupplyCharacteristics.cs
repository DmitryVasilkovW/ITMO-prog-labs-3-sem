using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Powersupplyunit.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

public class TableOfPowerSupplyCharacteristics : IPartCharacteristics, IPowerSupply
{
    public string? Name { get; init; }
    public int PeakLoad { get; init; }
}