using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class SpaceWhale : Entities.IObstacles
{
    private string _damageType;

    public SpaceWhale()
    {
        _damageType = "SpaceWhale";
    }

    public void Damage(Spaceship.Entities.Spaceship ship)
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
    }
}