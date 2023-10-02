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

    public new string DamageType
    {
        get { return _damageType; }
    }

    public new bool Isoperates
    {
        get { return _isoperates; }
        protected set { _isoperates = value; }
    }

    public override void Effect(Entities.Deflectors deflector)
    {
        deflector.SavingStatusOfTheDeflector(_damageType);
    }

    public override void Effect(Entities.Armor armor)
    {
        armor.SavingStatusOfTheArmor(_damageType);
    }
}