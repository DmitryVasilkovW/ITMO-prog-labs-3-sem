using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class NitrinoParticleNebulae : Entities.Environment
{
    private Services.Nebulae _nebulae;
    private Services.SpaceWhale _spaceWhale;
    private Spaceship.Entities.Spaceship _ship;
    private string _requiredEngine;
    private string _requiredMotorOperationType;
    private int _length;
    private int _countOfFirstTypeObstracles;
    private int _countOfSecondTypeObstracles;

    public NitrinoParticleNebulae(int length, int countOfFirstTypeObstracles, int countOfSecondTypeObstracles, Spaceship.Entities.Spaceship ship)
        : base(length, countOfFirstTypeObstracles, countOfSecondTypeObstracles, ship)
    {
        _requiredEngine = "PulseEngine";
        _requiredMotorOperationType = "Exponent";
        _spaceWhale = new SpaceWhale();
        _nebulae = new Nebulae();
        _ship = ship;
        _countOfFirstTypeObstracles = countOfFirstTypeObstracles;
        _countOfSecondTypeObstracles = countOfSecondTypeObstracles;
        _length = length;
    }

    public new int Length
    {
        get { return _length; }
    }

    public override string FirstTypeObstracleType
    {
        get { return _nebulae.DamageType; }
    }

    public override string SecondTypeObstracleType
    {
        get { return _spaceWhale.DamageType; }
    }

    public new bool IsTheShipWasAbleToRemainInService()
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
        if (_ship.EngineType.Equals(_requiredEngine, StringComparison.Ordinal) && _ship.Engine.MotorOperationType.Equals(_requiredMotorOperationType, StringComparison.Ordinal))
        {
            return true;
        }

        return false;
    }

    public void NebulaeDamage()
    {
        if (_ship.EngineType == "PulseEngine")
        _nebulae.Damage(_ship);
    }

    public void SpaceWhaleDamage()
    {
        _spaceWhale.Damage(_ship);
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
            if (_ship.IsShipAlive())
            {
                _ship = _spaceWhale.Damage(_ship);
            }
        }
    }

    protected override void TakingDamageFromAllObstaclesOfTheSecondType()
    {
        while (_countOfSecondTypeObstracles-- > 0)
        {
            if (_ship.Speed > 0)
            {
                _ship = _nebulae.Damage(_ship);
            }
        }
    }
}