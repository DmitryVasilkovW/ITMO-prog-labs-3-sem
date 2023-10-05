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
    private string _shipName;

    private IEnginesType _engine;
    private IJumpEngine _jumpEngine;
    private Armor _armor;

    public SlowMovingShuttle()
    {
        var engine = new ClassCPulseEngine(1);
        var armor = new FirstClassArmor(1);
        string engineType = "PulseEngine";
        var jumpEngine = new JumpEngineSlot();
        int weightDimensionCharacteristics = 1;

        _shipName = "SlowMovingShuttle";
        _nebulaDamage = 1000;
        _jumpEngine = jumpEngine;
        _speed = 100;
        _armor = armor;
        _engine = engine;
        _engineType = engineType;
        _weightDimensionCharacteristics = weightDimensionCharacteristics;
    }

    public override string ShipName
    {
        get { return _shipName; }
    }

    public override IEnginesType Engine
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

    public override bool IsTheStaffAlive()
    {
        if (_crew)
        {
            return true;
        }

        return false;
    }

    public override bool IsShipAlive()
    {
        if (_armor.IsArmorWorking() && _speed > 0)
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

    public override void ObstructionOfFlight()
    {
        _speed -= _nebulaDamage;
    }
}