namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

public abstract class AdditionalSafetyDevices
{
    private bool _isoperates;
    private string _damageType;

    protected AdditionalSafetyDevices(string damageType)
    {
        _isoperates = true;
        _damageType = damageType;
    }

    public virtual string DamageType
    {
        get { return _damageType; }
    }

    public virtual bool Isoperates
    {
        get { return _isoperates; }
        protected set { _isoperates = value; }
    }

    public abstract void Effect(Deflectors deflector);

    public abstract void Effect(IArmor armor, int weightDimensionsOfTheShip);
}