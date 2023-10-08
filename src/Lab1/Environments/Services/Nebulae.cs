using System;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class Nebulae : Entities.IObstacle
{
    private string _damageType;

    public Nebulae()
    {
        _damageType = "Nebulae";
    }

    public string DamageType
    {
        get { return _damageType; }
    }

    public ISpaceship Damage(ISpaceship ship)
    {
        if (ship.Engine is IEnginesType || !ship.Engine.MotorOperationType.Equals("Exponent", StringComparison.Ordinal))
        {
            ship.ObstructionOfFlight();
        }

        return ship;
    }
}