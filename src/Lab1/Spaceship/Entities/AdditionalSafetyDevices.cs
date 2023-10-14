namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

public abstract class AdditionalSafetyDevices
{
    public abstract void Effect(Deflectors deflector, AdditionalSafetyDevices device);

    public abstract void Effect(IArmor armor, int weightDimensionsOfTheShip, AdditionalSafetyDevices device);
}