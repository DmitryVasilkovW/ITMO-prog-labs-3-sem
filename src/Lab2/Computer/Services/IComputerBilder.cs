namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services;

public interface IComputerBilder
{
     IComputerBilder BuildMotherboard();
     IComputerBilder BuildCPU();
     IComputerBilder BuildBIOS();
     IComputerBilder BuildCPUCoolingSystem();
     IComputerBilder BuildRAM();
     IComputerBilder BuildSSDDrive();
     IComputerBilder BuildHardDrive();
     IComputerBilder BuildCase();
     IComputerBilder BuildPowerSupply();
}