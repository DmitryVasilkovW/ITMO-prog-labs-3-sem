namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Services;

public interface ICPUFactory
{
    ICPU GetCpu(
        string? name,
        bool availabilityOfABuiltInVideoCore,
        int supportedMemoryFrequencies,
        int heatEmission,
        int consumptionPower,
        int coreFrequency,
        int numberOfCores);
}