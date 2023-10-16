namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Services;

public interface ICPU
{
    public string? Name { get; init; }
    public bool AvailabilityOfABuiltInVideoCore { get; }
    public int SupportedMemoryFrequencies { get; }
    public int HeatEmission { get; }
    public int ConsumptionPower { get; }
    public int CoreFrequency { get; }
    public int NumberOfCores { get; }
}