using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Services;

public class CPUFactory : ICPUFactory
{
    private string? _name;
    private bool _availabilityOfABuiltInVideoCore;
    private int _supportedMemoryFrequencies;
    private int _heatEmission;
    private int _consumptionPower;
    private int _coreFrequency;
    private int _numberOfCores;

    public CPUFactory(
        string name,
        bool availabilityOfABuiltInVideoCore,
        int supportedMemoryFrequencies,
        int heatEmission,
        int consumptionPower,
        int coreFrequency,
        int numberOfCores)
    {
        _name = name;
        _availabilityOfABuiltInVideoCore = availabilityOfABuiltInVideoCore;
        _supportedMemoryFrequencies = supportedMemoryFrequencies;
        _heatEmission = heatEmission;
        _consumptionPower = consumptionPower;
        _coreFrequency = coreFrequency;
        _numberOfCores = numberOfCores;
    }

    public ICPU GetCpu()
    {
        LGA1700 membership = new()
        {
            Name = _name,
            AvailabilityOfABuiltInVideoCore = _availabilityOfABuiltInVideoCore,
            SupportedMemoryFrequencies = _supportedMemoryFrequencies,
            HeatEmission = _heatEmission,
            ConsumptionPower = _consumptionPower,
            CoreFrequency = _coreFrequency,
            NumberOfCores = _numberOfCores,
        };

        return membership;
    }
}