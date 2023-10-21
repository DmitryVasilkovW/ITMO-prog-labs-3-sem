using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

public class TableOfCPUCharacteristics : IPartCharacteristics, ICPU
{
    public TableOfCPUCharacteristics(
        string? name,
        bool availabilityOfABuiltInVideoCore,
        int supportedMemoryFrequencies,
        int heatEmission,
        int consumptionPower,
        int coreFrequency,
        int numberOfCores,
        ISocket socket)
    {
        Name = name;
        AvailabilityOfABuiltInVideoCore = availabilityOfABuiltInVideoCore;
        SupportedMemoryFrequencies = supportedMemoryFrequencies;
        HeatEmission = heatEmission;
        ConsumptionPower = consumptionPower;
        CoreFrequency = coreFrequency;
        NumberOfCores = numberOfCores;
        Socket = socket;
    }

    public string? Name { get; }
    public bool AvailabilityOfABuiltInVideoCore { get; }
    public int SupportedMemoryFrequencies { get; }
    public int HeatEmission { get; }
    public int ConsumptionPower { get; }
    public int CoreFrequency { get; }
    public int NumberOfCores { get; }
    public ISocket? Socket { get; }
}