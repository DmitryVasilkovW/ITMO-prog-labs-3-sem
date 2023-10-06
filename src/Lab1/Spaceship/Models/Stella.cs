using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Stella : Entities.ISpaceship
{
    private int _speed;
    private int _range;
    private int _fuelreserve;
    private int _gravitonmatter;
    private int _weightDimensionCharacteristics;
    private int _nebulaDamage;
    private bool _crew;
    private string _shipName;
    private string _engineType;

    private IEnginesType _engine;
    private IJumpEngine _jumpengine;
    private Deflectors _deflector;
    private IArmor _armor;
    private AdditionalSafetyDevices _equipment;

    public Stella(bool whethertoInstallAPhotonicDeflector)
    {
        _weightDimensionCharacteristics = 1;
        _equipment = new AdditionalSafetyDevicesSlot("none");
        _shipName = "Stella";
        _nebulaDamage = 1000;
        _armor = new FirstClassArmor(_weightDimensionCharacteristics);
        _jumpengine = new JumpEngineOmega(_weightDimensionCharacteristics);
        _engine = new ClassCPulseEngine(_weightDimensionCharacteristics);
        _engineType = "Jumpengine";

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

    public bool IsPhotonDeflectorWorking { get; }

    public int Speed
    {
        get { return _speed; }
    }

    public int Fuelreserve
    {
        get
        {
            Enginew();
            return _fuelreserve;
        }
    }

    public string ShipName
    {
        get { return _shipName; }
    }

    public IEnginesType Engine
    {
        get { return _engine; }
    }

    public IJumpEngine JumpEngine
    {
        get { return _jumpengine; }
    }

    public Deflectors Deflector
    {
        get { return _deflector; }
    }

    public IArmor Armor
    {
        get { return _armor; }
    }

    public AdditionalSafetyDevices Equipment
    {
        get { return _equipment; }
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

    public bool IsjumpEngineInstalled()
    {
        if (_jumpengine.ISSlot())
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

    public bool IsShipAlive()
    {
        if ((_armor.IsArmorWorking() || _deflector.IsDeflectorWorking()) && _speed > 0)
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
        _range = _jumpengine.Range(_range);
        _gravitonmatter = _jumpengine.FuelConsumption(_gravitonmatter);
    }
}