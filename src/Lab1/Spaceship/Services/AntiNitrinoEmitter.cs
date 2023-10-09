using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class AntiNitrinoEmitter : AdditionalSafetyDevices, ISpaceWhaleDefense
{
    public override void Effect(Deflectors deflector, AdditionalSafetyDevices device)
    {
        deflector.SavingStatusOfTheDeflector(device);
    }

    public override void Effect(IArmor armor, int weightDimensionsOfTheShip, AdditionalSafetyDevices device)
    {
        armor.SavingStatusOfTheArmor(weightDimensionsOfTheShip, device);
    }
}