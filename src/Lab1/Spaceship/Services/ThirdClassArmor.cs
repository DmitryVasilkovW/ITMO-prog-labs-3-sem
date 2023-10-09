using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class ThirdClassArmor : Entities.IArmor
{
    private const int Meteoritedamage = 200;
    private const int Asteroiddamage = 50;
    private const int Spacewhaledamage = 3000;

    private int _armorconditionlevel;
    private bool _isArmorWorking;

    public ThirdClassArmor()
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

    public void SavingStatusOfTheArmor(int weightDimensionsOfTheShip, AdditionalSafetyDevices device)
    {
        if (device is ISpaceWhaleDefense)
        {
            _armorconditionlevel += Spacewhaledamage / weightDimensionsOfTheShip;
        }
    }
}