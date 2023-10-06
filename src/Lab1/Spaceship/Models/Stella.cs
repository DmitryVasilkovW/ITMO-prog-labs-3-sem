using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Stella : Entities.ISpaceship
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

    private IEnginesType _engine;
    private IJumpEngine _jumpengine;
    private Deflectors _deflector;
    private Armor _armor;
    private AdditionalSafetyDevices _equipment;

    public Stella(bool whethertoInstallAPhotonicDeflector)
    {
        var engine = new ClassCPulseEngine(1);
        var jumpengine = new JumpEngineOmega(1);
        var armor = new FirstClassArmor(1);
        string engineType = "Jumpengine";
        int weightDimensionCharacteristics = 1;

        _equipment = new AdditionalSafetyDevicesSlot("none");
        _shipName = "Stella";
        _nebulaDamage = 1000;
        _armor = armor;
        _jumpengine = jumpengine;
        _engine = engine;
        _engineType = engineType;
        _weightDimensionCharacteristics = weightDimensionCharacteristics;

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

    public Armor Armor
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