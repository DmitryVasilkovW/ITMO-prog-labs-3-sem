using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Powersupplyunit.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Factory;

public class PowerSupplyFactory : IPartFactory<PowerSupply, TableOfPowerSupplyCharacteristics>
{
    public PowerSupply CreatePart(TableOfPowerSupplyCharacteristics characteristics)
    {
        string? name = characteristics.Name;
        int peakLoad = characteristics.PeakLoad;

        return new PowerSupply(name, peakLoad);
    }
}