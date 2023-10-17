using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Services;

public class LGA1700CPUFactory : ICPUFactory
{
    public ICPU GetCpu(
        string? name,
        bool availabilityOfABuiltInVideoCore,
        int supportedMemoryFrequencies,
        int heatEmission,
        int consumptionPower,
        int coreFrequency,
        int numberOfCores)
    {
        LGA1700 membership = new()
        {
            Name = name,
            AvailabilityOfABuiltInVideoCore = availabilityOfABuiltInVideoCore,
            SupportedMemoryFrequencies = supportedMemoryFrequencies,
            HeatEmission = heatEmission,
            ConsumptionPower = consumptionPower,
            CoreFrequency = coreFrequency,
            NumberOfCores = numberOfCores,
        };

        return membership;
    }
}