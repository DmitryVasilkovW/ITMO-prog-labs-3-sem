using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Models;

public interface ICPU
{
    string? Name { get; init; }
    bool AvailabilityOfABuiltInVideoCore { get; }
    int SupportedMemoryFrequencies { get; }
    int HeatEmission { get; }
    int ConsumptionPower { get; }
    int CoreFrequency { get; }
    int NumberOfCores { get; }
    ISocket? Socket { get; init; }
}