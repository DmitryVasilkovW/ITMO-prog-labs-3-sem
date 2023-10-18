using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

public class TableOfCPUCharacteristics : IPartCharacteristics, ICPU
{
    public string? Name { get; init; }
    public bool AvailabilityOfABuiltInVideoCore { get; init; }
    public int SupportedMemoryFrequencies { get; init; }
    public int HeatEmission { get; init; }
    public int ConsumptionPower { get; init; }
    public int CoreFrequency { get; init; }
    public int NumberOfCores { get; init; }
    public ISocket? Socket { get; init; }
}