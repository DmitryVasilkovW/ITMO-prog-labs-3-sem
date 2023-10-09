using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class AdditionalSafetyDevicesSlot : AdditionalSafetyDevices
{
    private bool _isoperates;

    public AdditionalSafetyDevicesSlot()
    {
        _isoperates = false;
    }

    public override bool Isoperates
    {
        get { return _isoperates; }
        protected set { _isoperates = value; }
    }

    public override void Effect(Deflectors deflector, AdditionalSafetyDevices device)
    {
    }

    public override void Effect(IArmor armor, int weightDimensionsOfTheShip, AdditionalSafetyDevices device)
    {
    }
}