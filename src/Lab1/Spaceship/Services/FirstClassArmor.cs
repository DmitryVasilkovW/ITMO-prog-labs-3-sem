using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class FirstClassArmor : IArmor
{
    private const int TakingMeteoritedamage = 2000;
    private const int TakingAsteroiddamage = 1000;
    private const int TakingSpacewhaledamage = 6000;
    private const int InitialArmorconditionlevel = 1000;

    private int _armorconditionlevel;
    private bool _isArmorWorking;

    public FirstClassArmor()
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