using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class Asteroid : IObstacle, IHullDamage
{
    private string _damageType;

    public Asteroid()
    {
        _damageType = "Asteroid";
    }

    public string DamageType
    {
        get { return _damageType; }
    }

    public ISpaceship Damage(ISpaceship ship, AdditionalSafetyDevices device)
    {
        if (ship.Deflector.IsDeflectorWorking())
        {
            ship.Deflector.AsteroidDamage();
        }
        else
        {
            ship.Armor.AsteroidDamage(ship.WeightDimensionCharacteristics);
        }

        return ship;
    }
}