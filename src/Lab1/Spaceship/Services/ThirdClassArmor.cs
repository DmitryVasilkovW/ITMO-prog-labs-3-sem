using System;
namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class ThirdClassArmor : Entities.IArmor
{
    private const int Meteoritedamage = 200;
    private const int Asteroiddamage = 50;
    private const int Spacewhaledamage = 3000;

    private int _armorconditionlevel;
    private bool _isArmorWorking;
    private int _weightDimensionsOfTheShip;

    public ThirdClassArmor(int weightDimensionsOfTheShip)
    {
        _weightDimensionsOfTheShip = weightDimensionsOfTheShip;
        _armorconditionlevel = 1000;
        _isArmorWorking = true;
    }

    public bool IsArmorWorking()
    {
        if (_armorconditionlevel < 0)
        {
            _isArmorWorking = false;
        }

        return _isArmorWorking;
    }

    public void AsteroidDamage()
    {
        _armorconditionlevel -= Asteroiddamage / _weightDimensionsOfTheShip;
        IsArmorWorking();
    }

    public void MeteoriteDamage()
    {
        _armorconditionlevel -= Meteoritedamage / _weightDimensionsOfTheShip;
        IsArmorWorking();
    }

    public void SpaceWhaleDamage()
    {
        _armorconditionlevel -= Spacewhaledamage / _weightDimensionsOfTheShip;
        IsArmorWorking();
    }

    public void SavingStatusOfTheArmor(string damagetype)
    {
        if (damagetype.Equals("SpaceWhale", StringComparison.Ordinal))
        {
            _armorconditionlevel += Spacewhaledamage / _weightDimensionsOfTheShip;
        }
        else if (damagetype.Equals("Meteorit", StringComparison.Ordinal))
        {
            _armorconditionlevel += Meteoritedamage / _weightDimensionsOfTheShip;
        }
        else
        {
            _armorconditionlevel += Asteroiddamage / _weightDimensionsOfTheShip;
        }
    }
}