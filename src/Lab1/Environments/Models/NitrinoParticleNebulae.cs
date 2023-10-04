using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class NitrinoParticleNebulae : Entities.Environment
{
    private Services.Nebulae _nebulae;
    private Services.SpaceWhale _spaceWhale;
    private Spaceship.Entities.Spaceship _ship;
    private string _requiredEngine;
    private string _requiredMotorOperationType;
    private int _length;

    public NitrinoParticleNebulae(Services.Nebulae obstacles, Services.SpaceWhale spaceWhale, Spaceship.Entities.Spaceship ship, int length)
        : base(obstacles, spaceWhale, ship, length)
    {
        _spaceWhale = spaceWhale;
        _nebulae = obstacles;
        _ship = ship;
        _requiredEngine = "PulseEngine";
        _requiredMotorOperationType = "Exponent";
        _length = length;
    }

    public new int Length
    {
        get { return _length; }
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
}