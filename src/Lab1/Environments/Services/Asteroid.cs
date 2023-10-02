using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class Asteroid : Entities.IObstacles
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

    public void Damage(Spaceship.Entities.Spaceship ship)
    {
        if (ship.IsDeflectorWorking)
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
                ship.Armor.AsteroidDamage();
            }
            else
            {
                ship.Armor.AsteroidDamage();
            }
        }
    }
}