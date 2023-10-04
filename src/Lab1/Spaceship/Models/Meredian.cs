using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Meredian : Entities.Spaceship
{
    private int _speed;
    private int _fuelreserve;
    private string _engineType;
    private int _weightDimensionCharacteristics;
    private bool _crew;
    private int _nebulaDamage;

    private IEnginesType _engine;
    private IJumpEngine _jumpengine;
    private Deflectors _deflector;
    private Armor _armor;
    private AdditionalSafetyDevices _equipment;

    public Meredian()
    {
        var engine = new ClassEPulseEngine(_weightDimensionCharacteristics);
        var deflector = new SecondClassDeflector(new PhotonDeflectorSlot());
        var armor = new SecondClassArmor(_weightDimensionCharacteristics);
        var equipment = new AntiNitrinoEmitter("SpaceWhale");
        var jumpEngine = new JumpEngineSlot();
        string engineType = "PulseEngine";
        int weightDimensionCharacteristics = 2;

        _nebulaDamage = 1000;
        _jumpengine = jumpEngine;
        _equipment = equipment;
        _armor = armor;
        _deflector = deflector;
        _engine = engine;
        _engineType = engineType;
        _weightDimensionCharacteristics = weightDimensionCharacteristics;
    }

    public new IEnginesType Engine
    {
        get { return _engine; }
    }

    public new Deflectors Deflector
    {
        get { return _deflector; }
    }

    public new Armor Armor
    {
        get { return _armor; }
    }

    public override int WeightDimensionCharacteristics
    {
        get { return _weightDimensionCharacteristics; }
    }

    public override string EngineType
    {
        get { return _engineType; }
    }

    public new bool IsTheStaffAlive()
    {
        if (_crew)
        {
            return true;
        }

        return false;
    }

    public new bool IsjumpEngineInstalled()
    {
        if (_jumpengine.ISSlot())
        {
            return false;
        }

        return true;
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

    public override void JumpEnginew()
    {
    }
}