using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class Meteorites : IObstacle, IHullDamage
{
    private string _damageType;

    public Meteorites()
    {
        _damageType = "Meteorit";
    }

    public string DamageType
    {
        get { return _damageType; }
    }

    public ISpaceship Damage(ISpaceship ship, AdditionalSafetyDevices device)
    {
        if (ship.Deflector.IsDeflectorWorking())
        {
            ship.Deflector.MeteoriteDamage();
        }
        else
        {
            ship.Armor.MeteoriteDamage(ship.WeightDimensionCharacteristics);
        }

        return ship;
    }
}