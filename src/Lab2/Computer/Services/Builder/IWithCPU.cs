using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services;

public interface IWithCPU
{
    IWithCPUCoolingSystem WithCPU(Processor processor);
}