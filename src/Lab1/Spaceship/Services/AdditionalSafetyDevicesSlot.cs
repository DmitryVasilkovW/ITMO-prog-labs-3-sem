using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class AdditionalSafetyDevicesSlot : Entities.AdditionalSafetyDevices
{
    private bool _isoperates;
    private string _damageType;

    public AdditionalSafetyDevicesSlot(string damageType)
        : base(damageType)
    {
        _isoperates = false;
        _damageType = damageType;
    }

    public override string DamageType
    {
        get { return _damageType; }
    }

    public override bool Isoperates
    {
        get { return _isoperates; }
        protected set { _isoperates = value; }
    }

    public override void Effect(Deflectors deflector)
    {
    }

    public override void Effect(Armor armor)
    {
    }
}