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
    private int _countOfObstracles;

    public NormalSpace(int length, int countOfObstracles, Spaceship.Entities.Spaceship ship)
        : base(length, countOfObstracles, ship)
    {
        _asteroid = new Asteroid();
        _meteorites = new Meteorites();
        _requiredEngine = "PulseEngine";
        _ship = ship;
        _countOfObstracles = countOfObstracles;
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