namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class AntiNitrinoEmitter : Entities.AdditionalSafetyDevices
{
    private bool _isoperates;
    private string _damageType;

    public AntiNitrinoEmitter(string damageType)
        : base(damageType)
    {
        _isoperates = true;
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

    public override void Effect(Entities.Deflectors deflector)
    {
        deflector.SavingStatusOfTheDeflector(_damageType);
    }

    public override void Effect(Entities.IArmor armor, int weightDimensionsOfTheShip)
    {
        armor.SavingStatusOfTheArmor(_damageType, weightDimensionsOfTheShip);
    }
}