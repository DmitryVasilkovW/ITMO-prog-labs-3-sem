using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class SecondClassArmor : IArmor
{
    private const int TakingMeteoritedamage = 500;
    private const int TakingAsteroiddamage = 200;
    private const int TakingSpacewhaledamage = 3000;
    private const int InitialArmorconditionlevel = 1000;

    private int _armorconditionlevel;
    private bool _isArmorWorking;

    public SecondClassArmor()
    {
        _armorconditionlevel = InitialArmorconditionlevel;
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
        _armorconditionlevel -= TakingAsteroiddamage / weightDimensionsOfTheShip;
        IsArmorWorking();
    }

    public void MeteoriteDamage(int weightDimensionsOfTheShip)
    {
        _armorconditionlevel -= TakingMeteoritedamage / weightDimensionsOfTheShip;
        IsArmorWorking();
    }

    public void SpaceWhaleDamage(int weightDimensionsOfTheShip)
    {
        _armorconditionlevel -= TakingSpacewhaledamage / weightDimensionsOfTheShip;
        IsArmorWorking();
    }

    public void SavingStatusOfTheArmor(int weightDimensionsOfTheShip, AdditionalSafetyDevices device)
    {
        if (device is ISpaceWhaleDefense)
        {
            _armorconditionlevel += TakingSpacewhaledamage / weightDimensionsOfTheShip;
        }
    }
}