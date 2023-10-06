using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class SlowMovingShuttle : Entities.ISpaceship
{
    private int _speed;
    private int _fuelreserve;
    private int _gravitonmatter;
    private string _engineType;
    private int _weightDimensionCharacteristics;
    private bool _crew;
    private int _nebulaDamage;
    private string _shipName;
    private int _range;

    private IEnginesType _engine;
    private Armor _armor;
    private Deflectors _deflector;
    private IJumpEngine _jumpEngine;
    private AdditionalSafetyDevices _equipment;

    public SlowMovingShuttle()
    {
        var engine = new ClassCPulseEngine(1);
        var armor = new FirstClassArmor(1);
        string engineType = "PulseEngine";
        var jumpEngine = new JumpEngineSlot();
        int weightDimensionCharacteristics = 1;

        _equipment = new AdditionalSafetyDevicesSlot("none");
        _deflector = new DeflectorSlot(new PhotonDeflectorSlot());
        _shipName = "SlowMovingShuttle";
        _nebulaDamage = 1000;
        _jumpEngine = jumpEngine;
        _speed = 100;
        _range = 0;
        _armor = armor;
        _engine = engine;
        _engineType = engineType;
        _weightDimensionCharacteristics = weightDimensionCharacteristics;
    }

    public bool IsPhotonDeflectorWorking
    {
        get { return _deflector.IsaPhotonDeflectorInstalled; }
    }

    public IJumpEngine JumpEngine
    {
        get { return _jumpEngine; }
    }

    public AdditionalSafetyDevices Equipment
    {
        get { return _equipment; }
    }

    public Deflectors Deflector
    {
        get { return _deflector; }
    }

    public Armor Armor
    {
        get { return _armor; }
    }

    public int Speed
    {
        get { return _speed; }
    }

    public string ShipName
    {
        get { return _shipName; }
    }

    public IEnginesType Engine
    {
        get { return _engine; }
    }

    public int WeightDimensionCharacteristics
    {
        get { return _weightDimensionCharacteristics; }
    }

    public string EngineType
    {
        get { return _engineType; }
    }

    public bool IsDeflectorWorking
    {
        get { return _deflector.IsDeflectorWorking(); }
    }

    public void SafetyEquipmentOperation()
    {
        if (_deflector.IsDeflectorWorking())
        {
            _equipment.Effect(_deflector);
        }
        else
        {
            _equipment.Effect(_armor);
        }
    }

    public bool IsjumpEngineInstalled()
    {
        if (_jumpEngine.ISSlot())
        {
            return false;
        }

        return true;
    }

    public bool IsTheStaffAlive()
    {
        if (_crew)
        {
            return true;
        }

        return false;
    }

    public bool IsShipAlive()
    {
        if (_armor.IsArmorWorking() && _speed > 0)
        {
            return true;
        }

        return false;
    }

    public void Enginew()
    {
        _speed = _engine.Speed(_speed);
        _fuelreserve = _engine.FuelConsumption(_fuelreserve);
    }

    public void StaffAssault()
    {
        _crew ^= true;
    }

    public void ObstructionOfFlight()
    {
        _speed -= _nebulaDamage;
    }

    public void JumpEnginew()
    {
        _range = _jumpEngine.Range(_range);
        _gravitonmatter = _jumpEngine.FuelConsumption(_gravitonmatter);
    }
}