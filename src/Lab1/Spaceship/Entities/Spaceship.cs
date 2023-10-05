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
    private int _nebulaDamage;
    private string _shipName;

    private Deflectors _deflector;
    private IEnginesType _engine;
    private IJumpEngine _jumpengine;
    private Armor _armor;
    private AdditionalSafetyDevices _equipment;

    protected Spaceship(bool whethertoInstallAPhotonicDeflector)
    {
        var jumpengineslot = new JumpEngineSlot();
        var engine = new ClassCPulseEngine(_weightDimensionCharacteristics);
        var armor = new FirstClassArmor(1);
        var equipment = new AdditionalSafetyDevicesSlot(" ");

        _shipName = " ";
        _nebulaDamage = 1000;
        _equipment = equipment;
        _armor = armor;
        _engine = engine;
        _jumpengine = jumpengineslot;
        _engineType = "d";
        _weightDimensionCharacteristics = 1;
        _crew = true;

        if (whethertoInstallAPhotonicDeflector)
        {
            var deflector = new FirstClassDeflector(new StandardPhotonicDeflectors());
            _deflector = deflector;
        }
        else
        {
            var deflector = new FirstClassDeflector();
            _deflector = deflector;
        }
    }

    protected Spaceship()
    {
        var fslot = new PhotonDeflectorSlot();
        var slot = new DeflectorSlot(fslot);
        var jumpengineslot = new JumpEngineSlot();
        var engine = new ClassCPulseEngine(_weightDimensionCharacteristics);
        var armor = new FirstClassArmor(1);
        var equipment = new AdditionalSafetyDevicesSlot(" ");

        _shipName = " ";
        _nebulaDamage = 1000;
        _speed = 100;
        _equipment = equipment;
        _armor = armor;
        _deflector = slot;
        _engine = engine;
        _jumpengine = jumpengineslot;
        _engineType = "d";
        _weightDimensionCharacteristics = 1;
        _crew = true;
    }

    public virtual string ShipName
    {
        get { return _shipName; }
    }

    public virtual bool IsDeflectorWorking
    {
         get { return _deflector.IsDeflectorWorking(); }
    }

    public virtual bool IsPhotonDeflectorWorking
    {
        get { return _deflector.IsaPhotonDeflectorInstalled; }
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

    public virtual bool IsShipAlive()
    {
        if ((_armor.IsArmorWorking() || _deflector.IsDeflectorWorking()) && _speed > 0)
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
        _speed -= _nebulaDamage;
    }

    public virtual void JumpEnginew()
    {
        _range = _jumpengine.Range(_range);
        _gravitonmatter = _jumpengine.FuelConsumption(_gravitonmatter);
    }
}