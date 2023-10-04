using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

public abstract class Spaceship
{
    private int _speed;
    private int _range;
    private int _fuelreserve;
    private int _gravitonmatter;
    private string _engineType;
    private int _weightDimensionCharacteristics;
    private bool _crew;

    private Deflectors _deflector;
    private IEnginesType _engine;
    private IJumpEngine _jumpengine;
    private Armor _armor;
    private AdditionalSafetyDevices _equipment;

    protected Spaceship()
    {
        var fslot = new PhotonDeflectorSlot();
        var slot = new DeflectorSlot(fslot);
        var jumpengineslot = new JumpEngineSlot();
        var engine = new ClassCPulseEngine(_weightDimensionCharacteristics);
        var armor = new FirstClassArmor(1);
        var equipment = new AdditionalSafetyDevicesSlot(" ");

        _equipment = equipment;
        _armor = armor;
        _deflector = slot;
        _engine = engine;
        _jumpengine = jumpengineslot;
        _engineType = "d";
        _weightDimensionCharacteristics = 1;
        _crew = true;
    }

    private Spaceship(Deflectors deflector, IEnginesType engine, IJumpEngine jumpengine, string engineType, int weightDimensionCharacteristics, Armor armor, AdditionalSafetyDevices equipment)
    {
        _deflector = deflector;
        _equipment = equipment;
        _engine = engine;
        _armor = armor;
        _jumpengine = jumpengine;
        _engineType = engineType;
        _weightDimensionCharacteristics = weightDimensionCharacteristics;
    }

    public virtual bool IsDeflectorWorking
    {
         get { return _deflector.IsDeflectorWorking(); }
    }

    public virtual int Speed
    {
        get { return _speed; }
    }

    public virtual IEnginesType Engine
    {
        get { return _engine; }
    }

    public virtual IJumpEngine JumpEngine
    {
        get { return _jumpengine; }
    }

    public virtual Deflectors Deflector
    {
        get { return _deflector; }
    }

    public virtual Armor Armor
    {
        get { return _armor; }
    }

    public virtual AdditionalSafetyDevices Equipment
    {
        get { return _equipment; }
    }

    public virtual int WeightDimensionCharacteristics
    {
        get { return _weightDimensionCharacteristics; }
    }

    public virtual string EngineType
    {
        get { return _engineType; }
    }

    public bool IsjumpEngineInstalled()
    {
        if (_jumpengine.ISSlot())
        {
            return false;
        }

        return true;
    }

    public bool IsShipAlive()
    {
        if (_armor.IsArmorWorking() || _deflector.IsDeflectorWorking() || _speed > 0)
        {
            return true;
        }

        return false;
    }

    public virtual void Enginew()
    {
        _speed = _engine.Speed(_speed);
        _fuelreserve = _engine.FuelConsumption(_fuelreserve);
    }

    public virtual void StaffAssault()
    {
        _crew ^= true;
    }

    // сделать это в кораблях
    public virtual bool IsTheStaffAlive()
    {
        if (_crew)
        {
            return true;
        }

        return false;
    }

    public virtual void SafetyEquipmentOperation()
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

    public virtual void ObstructionOfFlight()
    {
        _speed -= 1000;
    }

    public virtual void JumpEnginew()
    {
        _range = _jumpengine.Range(_range);
        _gravitonmatter = _jumpengine.FuelConsumption(_gravitonmatter);
    }
}