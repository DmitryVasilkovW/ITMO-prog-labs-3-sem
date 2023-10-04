using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class Nebulae : Entities.IObstacles
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

    public Spaceship.Entities.Spaceship Damage(Spaceship.Entities.Spaceship ship)
    {
        if (ship.EngineType.Equals("PulseEngine", StringComparison.Ordinal) || !ship.Engine.MotorOperationType.Equals("Exponent", StringComparison.Ordinal))
        {
            ship.ObstructionOfFlight();
        }

        return ship;
    }
}