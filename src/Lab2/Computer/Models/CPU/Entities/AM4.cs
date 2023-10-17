using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Entities;

public class AM4 : ICPU
{
    public string? Name { get; init; }
    public bool AvailabilityOfABuiltInVideoCore { get; init; }
    public int SupportedMemoryFrequencies { get; init; }
    public int HeatEmission { get; init; }
    public int ConsumptionPower { get; init; }
    public int CoreFrequency { get; init; }
    public int NumberOfCores { get; init; }
}