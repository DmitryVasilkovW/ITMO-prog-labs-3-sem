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
    private int _nebulaDamage;

    private IEnginesType _engine;
    private IJumpEngine _jumpEngine;
    private Armor _armor;

    public SlowMovingShuttle()
        : base()
    {
        var engine = new ClassCPulseEngine(_weightDimensionCharacteristics);
        var armor = new FirstClassArmor(_weightDimensionCharacteristics);
        string engineType = "PulseEngine";
        var jumpEngine = new JumpEngineSlot();
        int weightDimensionCharacteristics = 1;

        _nebulaDamage = 1000;
        _jumpEngine = jumpEngine;
        _armor = armor;
        _engine = engine;
        _engineType = engineType;
        _weightDimensionCharacteristics = weightDimensionCharacteristics;
    }

    public new IEnginesType Engine
    {
        get { return _engine; }
    }

    public override int WeightDimensionCharacteristics
    {
        get { return _weightDimensionCharacteristics; }
    }

    public override string EngineType
    {
        get { return _engineType; }
    }

    public new bool IsjumpEngineInstalled()
    {
        if (_jumpEngine.ISSlot())
        {
            return false;
        }

        return true;
    }

    public new bool IsTheStaffAlive()
    {
        if (_crew)
        {
            return true;
        }

        return false;
    }

    public override void Enginew()
    {
        _speed = _engine.Speed(_speed);
        _fuelreserve = _engine.FuelConsumption(_fuelreserve);
    }

    public override void StaffAssault()
    {
        _crew ^= true;
    }

    public new void ObstructionOfFlight()
    {
        _speed -= _nebulaDamage;
    }
}