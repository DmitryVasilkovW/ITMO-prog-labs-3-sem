using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Powersupplyunit.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services;

public interface IWithPowerSupply
{
    IComputerBuilder WithPowerSupply(PowerSupply powerSupply);
}