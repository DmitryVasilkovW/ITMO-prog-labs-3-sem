namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

public abstract class AdditionalSafetyDevices
{
    private bool _isoperates;

    protected AdditionalSafetyDevices()
    {
        _isoperates = true;
    }

    public virtual bool Isoperates
    {
        get { return _isoperates; }
        protected set { _isoperates = value; }
    }

    public abstract void Effect(Deflectors deflector, AdditionalSafetyDevices device);

    public abstract void Effect(IArmor armor, int weightDimensionsOfTheShip, AdditionalSafetyDevices device);
}