using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class SlowMovingShuttle : Entities.Spaceship
{
    private int _speed;
    private int _fuelreserve;
    private string _engineType;
    private int _weightDimensionCharacteristics;
    private bool _crew;

    private IEnginesType _engine;

    public SlowMovingShuttle()
    {
        var engine = new ClassCPulseEngine();
        string engineType = "PulseEngine";
        int weightDimensionCharacteristics = 239;

        _engine = engine;
        _engineType = engineType;
        _weightDimensionCharacteristics = weightDimensionCharacteristics;
    }

    public override int WeightDimensionCharacteristics
    {
        get { return _weightDimensionCharacteristics; }
    }

    public override string EngineType
    {
        get { return _engineType; }
    }

    public override void Engine()
    {
        _speed = _engine.Speed(_speed);
        _fuelreserve = _engine.FuelConsumption(_fuelreserve);
    }

    public override void StaffAssault()
    {
        _crew ^= true;
    }

    public override void ObstructionOfFlight(int speedReduction)
    {
        _speed -= speedReduction;
    }
}