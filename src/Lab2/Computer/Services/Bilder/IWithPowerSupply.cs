using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Powersupplyunit.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services;

public interface IWithPowerSupply
{
    IComputerBilder WithPowerSupply(PowerSupply powerSupply);
}