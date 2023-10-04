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
    private int _countOfObstracles;

    public NitrinoParticleNebulae(int length, int countOfObstracles, Spaceship.Entities.Spaceship ship)
        : base(length, countOfObstracles, ship)
    {
        _requiredEngine = "PulseEngine";
        _requiredMotorOperationType = "Exponent";
        _spaceWhale = new SpaceWhale();
        _nebulae = new Nebulae();
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