using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Entities;

public class IntelCorei512400FOEM : ICPU
{
    public bool AvailabilityOfABuiltInVideoCore { get; }
    public int SupportedMemoryFrequencies { get; }
    public int HeatEmission { get; }
    public int ConsumptionPower { get; }
    public int CoreFrequency { get; }
    public int NumberOfCores { get; }
    public ISocket? Socket { get; }
    public string? Name { get; } = "Intel Core i5-12400F OEM";
}