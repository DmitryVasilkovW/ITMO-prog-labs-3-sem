using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class AntiNitrinoEmitter : AdditionalSafetyDevices, ISpaceWhaleDefense
{
    private bool _isoperates;

    public AntiNitrinoEmitter()
    {
        _isoperates = true;
    }

    public override bool Isoperates
    {
        get { return _isoperates; }
        protected set { _isoperates = value; }
    }

    public override void Effect(Deflectors deflector, AdditionalSafetyDevices device)
    {
        deflector.SavingStatusOfTheDeflector(device);
    }

    public override void Effect(IArmor armor, int weightDimensionsOfTheShip, AdditionalSafetyDevices device)
    {
        armor.SavingStatusOfTheArmor(weightDimensionsOfTheShip, device);
    }
}