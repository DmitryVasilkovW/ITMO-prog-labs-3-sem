using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class Asteroid : IObstacle, IHullDamage, INormalSpace
{
    public void Damage(ISpaceship ship, AdditionalSafetyDevices device)
    {
        if (ship.Deflector.IsDeflectorWorking())
        {
            ship.Deflector.AsteroidDamage();
        }
        else
        {
            ship.Armor.AsteroidDamage(ship.WeightDimensionCharacteristics);
        }
    }
}