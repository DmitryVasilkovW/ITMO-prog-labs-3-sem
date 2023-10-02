using System;
namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class SecondClassArmor : Entities.Armor
{
    private int _armorconditionlevel;
    private bool _isArmorWorking;

    public SecondClassArmor()
    {
        _armorconditionlevel = 1000;
        _isArmorWorking = true;
    }

    public new bool IsArmorWorking()
    {
        if (_armorconditionlevel < 0)
        {
            _isArmorWorking = false;
        }

        return _isArmorWorking;
    }

    public override void AsteroidDamage()
    {
        _armorconditionlevel -= 200;
        IsArmorWorking();
    }

    public override void MeteoriteDamage()
    {
        _armorconditionlevel -= 500;
        IsArmorWorking();
    }

    public override void SpaceWhaleDamage()
    {
        _armorconditionlevel -= 3000;
        IsArmorWorking();
    }

    public override void SavingStatusOfTheArmor(string damagetype)
    {
        if (damagetype.Equals("SpaceWhale", StringComparison.Ordinal))
        {
            _armorconditionlevel += 3000;
        }
        else if (damagetype.Equals("Meteorit", StringComparison.Ordinal))
        {
            _armorconditionlevel += 500;
        }
        else
        {
            _armorconditionlevel += 200;
        }
    }
}