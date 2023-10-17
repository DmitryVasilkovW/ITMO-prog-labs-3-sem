namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Services;

public interface ICPU
{
    string? Name { get; }
    bool AvailabilityOfABuiltInVideoCore { get; }
    int SupportedMemoryFrequencies { get; }
    int HeatEmission { get; }
    int ConsumptionPower { get; }
    int CoreFrequency { get; }
    int NumberOfCores { get; }
}