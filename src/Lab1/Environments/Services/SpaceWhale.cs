using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class SpaceWhale : IObstacle, IHullDamage
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

    public ISpaceship Damage(ISpaceship ship, AdditionalSafetyDevices device)
    {
        if (ship.Deflector.IsDeflectorWorking())
        {
            if (device is ISpaceWhaleDefense)
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
            if (device is ISpaceWhaleDefense)
            {
                ship.SafetyEquipmentOperation();
                ship.Armor.SpaceWhaleDamage(ship.WeightDimensionCharacteristics);
            }
            else
            {
                ship.Armor.SpaceWhaleDamage(ship.WeightDimensionCharacteristics);
            }
        }

        return ship;
    }
}