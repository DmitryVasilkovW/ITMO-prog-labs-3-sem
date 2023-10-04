using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class Meteorites : Entities.IObstacles
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

    public Spaceship.Entities.Spaceship Damage(Spaceship.Entities.Spaceship ship)
    {
        if (ship.IsDeflectorWorking)
        {
            if (_damageType.Equals(ship.Equipment.DamageType, StringComparison.OrdinalIgnoreCase))
            {
                ship.SafetyEquipmentOperation();
                ship.Deflector.MeteoriteDamage();
            }
            else
            {
                ship.Deflector.MeteoriteDamage();
            }
        }
        else
        {
            if (_damageType.Equals(ship.Equipment.DamageType, StringComparison.OrdinalIgnoreCase))
            {
                ship.SafetyEquipmentOperation();
                ship.Armor.MeteoriteDamage();
            }
            else
            {
                ship.Armor.MeteoriteDamage();
            }
        }

        return ship;
    }
}