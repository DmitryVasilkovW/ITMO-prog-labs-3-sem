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

    public void Damage(Spaceship.Entities.Spaceship ship)
    {
        if (ship.EngineType.Equals("PulseEngine", StringComparison.Ordinal))
        {
            ship.ObstructionOfFlight(100);
        }
    }
}