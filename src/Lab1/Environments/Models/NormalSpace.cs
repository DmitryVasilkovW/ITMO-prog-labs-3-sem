using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class NormalSpace : Entities.Environment
{
    private Asteroid _asteroid;
    private Meteorites _meteorites;
    private Spaceship.Entities.ISpaceship _ship;
    private string _requiredEngine;
    private int _length;
    private int _countOfFirstTypeObstracles;
    private int _countOfSecondTypeObstracles;

    public NormalSpace(int length, int countOfFirstTypeObstracles, int countOfSecondTypeObstracles, Spaceship.Entities.ISpaceship ship)
        : base(length, countOfFirstTypeObstracles, countOfSecondTypeObstracles, ship)
    {
        _asteroid = new Asteroid();
        _meteorites = new Meteorites();
        _requiredEngine = "PulseEngine";
        _ship = ship;
        _countOfFirstTypeObstracles = countOfFirstTypeObstracles;
        _countOfSecondTypeObstracles = countOfSecondTypeObstracles;
        _length = length;
    }

    public override int Length
    {
        get { return _length; }
    }

    public override string FirstTypeObstracleType
    {
        get { return _asteroid.DamageType; }
    }

    public override string SecondTypeObstracleType
    {
        get { return _meteorites.DamageType; }
    }

    public override bool IsTheShipWasAbleToRemainInService()
    {
        TakingDamageFromAllObstaclesOfTheFirstType();

        if (!IsShipAlive())
        {
            return false;
        }

        TakingDamageFromAllObstaclesOfTheSecondType();

        if (!IsShipAlive())
        {
            return false;
        }

        return true;
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

    protected override bool IsShipAlive()
    {
        if (_ship.IsShipAlive())
        {
            return true;
        }

        return false;
    }

    protected override void TakingDamageFromAllObstaclesOfTheFirstType()
    {
        while (_countOfFirstTypeObstracles-- > 0)
        {
            _ship = _asteroid.Damage(_ship);
        }
    }

    protected override void TakingDamageFromAllObstaclesOfTheSecondType()
    {
        while (_countOfSecondTypeObstracles-- > 0)
        {
            _ship = _meteorites.Damage(_ship);
        }
    }
}