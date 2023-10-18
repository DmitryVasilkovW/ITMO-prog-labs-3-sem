using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Entities;

public class Processor : ICPU, IPart
{
    public Processor(TableOfCPUCharacteristics characteristics)
    {
        Name = characteristics.Name;
        AvailabilityOfABuiltInVideoCore = characteristics.AvailabilityOfABuiltInVideoCore;
        SupportedMemoryFrequencies = characteristics.SupportedMemoryFrequencies;
        HeatEmission = characteristics.HeatEmission;
        ConsumptionPower = characteristics.ConsumptionPower;
        CoreFrequency = characteristics.CoreFrequency;
        NumberOfCores = characteristics.NumberOfCores;
        Socket = characteristics.Socket;
    }

    public string? Name { get; init; }
    public bool AvailabilityOfABuiltInVideoCore { get; init; }
    public int SupportedMemoryFrequencies { get; init; }
    public int HeatEmission { get; init; }
    public int ConsumptionPower { get; init; }
    public int CoreFrequency { get; init; }
    public int NumberOfCores { get; init; }
    public ISocket? Socket { get; init; }
}