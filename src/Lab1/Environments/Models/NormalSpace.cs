using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class NormalSpace : Entities.Environment
{
    private Asteroid _asteroid;
    private Meteorites _meteorites;
    private Spaceship.Entities.Spaceship _ship;
    private string _requiredEngine;
    private int _length;

    public NormalSpace(Asteroid firstObstacles, Meteorites secondObstacles, Spaceship.Entities.Spaceship ship, int length)
        : base(firstObstacles, secondObstacles, ship, length)
    {
        _asteroid = firstObstacles;
        _meteorites = secondObstacles;
        _ship = ship;
        _requiredEngine = "PulseEngine";
        _length = length;
    }

    public new int Length
    {
        get { return _length; }
    }

    public override bool IsCanEnterTheEnvironment()
    {
        if (_ship.EngineType.Equals(_requiredEngine, StringComparison.Ordinal))
        {
            return true;
        }

        return false;
    }

    public void AsteroidDamage()
    {
        _asteroid.Damage(_ship);
    }

    public void MeteoriteDamage()
    {
        _meteorites.Damage(_ship);
    }
}