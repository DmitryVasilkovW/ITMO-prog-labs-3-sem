using System;
namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class FirstClassArmor : Entities.Armor
{
    private int _armorconditionlevel;
    private int _asteroidDamage;
    private int _meteoriteDamage;
    private int _spaceWhaleDamage;
    private bool _isArmorWorking;
    private int _weightDimensionsOfTheShip;

    public FirstClassArmor(int weightDimensionsOfTheShip)
        : base(weightDimensionsOfTheShip)
    {
        _weightDimensionsOfTheShip = weightDimensionsOfTheShip;
        _asteroidDamage = 1000;
        _meteoriteDamage = 2000;
        _spaceWhaleDamage = 6000;
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
        _armorconditionlevel -= _asteroidDamage / _weightDimensionsOfTheShip;
        IsArmorWorking();
    }

    public override void MeteoriteDamage()
    {
        _armorconditionlevel -= _meteoriteDamage / _weightDimensionsOfTheShip;
        IsArmorWorking();
    }

    public override void SpaceWhaleDamage()
    {
        _armorconditionlevel -= _spaceWhaleDamage / _weightDimensionsOfTheShip;
        IsArmorWorking();
    }

    public override void SavingStatusOfTheArmor(string damagetype)
    {
        if (damagetype.Equals("SpaceWhale", StringComparison.Ordinal))
        {
            _armorconditionlevel += _spaceWhaleDamage / _weightDimensionsOfTheShip;
        }
        else if (damagetype.Equals("Meteorit", StringComparison.Ordinal))
        {
            _armorconditionlevel += _meteoriteDamage / _weightDimensionsOfTheShip;
        }
        else
        {
            _armorconditionlevel += _asteroidDamage / _weightDimensionsOfTheShip;
        }
    }
}