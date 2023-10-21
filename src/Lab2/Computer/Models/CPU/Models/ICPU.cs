using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Models;

public interface ICPU : IPart
{
    bool AvailabilityOfABuiltInVideoCore { get; }
    int SupportedMemoryFrequencies { get; }
    int HeatEmission { get; }
    int ConsumptionPower { get; }
    int CoreFrequency { get; }
    int NumberOfCores { get; }
    ISocket? Socket { get; }
}