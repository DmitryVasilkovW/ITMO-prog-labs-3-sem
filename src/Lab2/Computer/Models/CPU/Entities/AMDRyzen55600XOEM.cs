using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Entities;

public class AMDRyzen55600XOEM : ICPU, IPart
{
    public bool AvailabilityOfABuiltInVideoCore { get; }
    public int SupportedMemoryFrequencies { get; }
    public int HeatEmission { get; }
    public int ConsumptionPower { get; }
    public int CoreFrequency { get; }
    public int NumberOfCores { get; }
    public ISocket? Socket { get; }
    public string? Name { get; } = "AMD Ryzen 5 5600X OEM";
}