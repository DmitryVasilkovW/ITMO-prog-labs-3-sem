using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class AdditionalSafetyDevicesSlot : AdditionalSafetyDevices
{
    public override void Effect(Deflectors deflector, AdditionalSafetyDevices device)
    {
    }

    public override void Effect(IArmor armor, int weightDimensionsOfTheShip, AdditionalSafetyDevices device)
    {
    }
}