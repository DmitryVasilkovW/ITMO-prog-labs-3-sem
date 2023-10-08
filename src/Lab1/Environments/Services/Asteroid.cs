using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class Asteroid : IObstacle
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

    public ISpaceship Damage(ISpaceship ship)
    {
        if (ship.Deflector.IsDeflectorWorking())
        {
            if (_damageType.Equals(ship.Equipment.DamageType, StringComparison.OrdinalIgnoreCase))
            {
                ship.SafetyEquipmentOperation();
                ship.Deflector.AsteroidDamage();
            }
            else
            {
                ship.Deflector.AsteroidDamage();
            }
        }
        else
        {
            if (_damageType.Equals(ship.Equipment.DamageType, StringComparison.OrdinalIgnoreCase))
            {
                ship.SafetyEquipmentOperation();
                ship.Armor.AsteroidDamage(ship.WeightDimensionCharacteristics);
            }
            else
            {
                ship.Armor.AsteroidDamage(ship.WeightDimensionCharacteristics);
            }
        }

        return ship;
    }
}