using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPUcoolingsystem.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services;

public interface IWithCPUCoolingSystem
{
    public IWithRAM WithCPUCoolingSystem(CPUCoolingSystem cpuCoolingSystem);
}