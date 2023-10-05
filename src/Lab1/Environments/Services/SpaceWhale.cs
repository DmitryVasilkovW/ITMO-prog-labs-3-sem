using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class SpaceWhale : Entities.IObstacles
{
    private string _damageType;

    public SpaceWhale()
    {
        _damageType = "SpaceWhale";
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
                ship.Deflector.SpaceWhaleDamage();
            }
            else
            {
                ship.Deflector.SpaceWhaleDamage();
            }
        }
        else
        {
            if (_damageType.Equals(ship.Equipment.DamageType, StringComparison.OrdinalIgnoreCase))
            {
                ship.SafetyEquipmentOperation();
                ship.Armor.SpaceWhaleDamage();
            }
            else
            {
                ship.Armor.SpaceWhaleDamage();
            }
        }

        return ship;
    }
}