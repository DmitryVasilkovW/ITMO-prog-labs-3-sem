using System;
namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class SecondClassArmor : Entities.IArmor
{
    private const int Meteoritedamage = 500;
    private const int Asteroiddamage = 200;
    private const int Spacewhaledamage = 3000;

    private int _armorconditionlevel;
    private bool _isArmorWorking;

    public SecondClassArmor()
    {
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

    public void AsteroidDamage(int weightDimensionsOfTheShip)
    {
        _armorconditionlevel -= Asteroiddamage / weightDimensionsOfTheShip;
        IsArmorWorking();
    }

    public void MeteoriteDamage(int weightDimensionsOfTheShip)
    {
        _armorconditionlevel -= Meteoritedamage / weightDimensionsOfTheShip;
        IsArmorWorking();
    }

    public void SpaceWhaleDamage(int weightDimensionsOfTheShip)
    {
        _armorconditionlevel -= Spacewhaledamage / weightDimensionsOfTheShip;
        IsArmorWorking();
    }

    public void SavingStatusOfTheArmor(string damagetype, int weightDimensionsOfTheShip)
    {
        if (damagetype.Equals("SpaceWhale", StringComparison.Ordinal))
        {
            _armorconditionlevel += Spacewhaledamage / weightDimensionsOfTheShip;
        }
        else if (damagetype.Equals("Meteorit", StringComparison.Ordinal))
        {
            _armorconditionlevel += Meteoritedamage / weightDimensionsOfTheShip;
        }
        else
        {
            _armorconditionlevel += Asteroiddamage / weightDimensionsOfTheShip;
        }
    }
}