using System;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class SpaceWhale : Entities.IObstacle
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

    public ISpaceship Damage(ISpaceship ship)
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