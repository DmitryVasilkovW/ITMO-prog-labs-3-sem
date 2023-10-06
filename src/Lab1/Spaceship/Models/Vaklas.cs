using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Vaklas : Entities.ISpaceship
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

    public Vaklas(bool whethertoInstallAPhotonicDeflector)
    {
        var engine = new ClassEPulseEngine(2);
        var jumpengine = new JumpEngineGamma(2);
        var armor = new SecondClassArmor(2);
        string engineType = "PulseEngine";
        int weightDimensionCharacteristics = 2;

        _equipment = new AdditionalSafetyDevicesSlot("none");
        _shipName = "Vaklas";
        _speed = 100;
        _nebulaDamage = 923333333;
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

    public bool IsPhotonDeflectorWorking
    {
        get { return _deflector.IsaPhotonDeflectorInstalled; }
    }

    public string ShipName
    {
        get { return _shipName; }
    }

    public int Speed => _speed;

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

    public int WeightDimensionCharacteristics
    {
        get { return _weightDimensionCharacteristics; }
    }

    public string EngineType
    {
        get { return _engineType; }
    }

    public AdditionalSafetyDevices Equipment
    {
        get { return _equipment; }
    }

    public int Fuelreserve
    {
        get
        {
            Enginew();
            return _fuelreserve;
        }
    }

    public bool IsDeflectorWorking
    {
        get { return _deflector.IsDeflectorWorking(); }
    }

    public void Enginew()
    {
        _speed = _engine.Speed(_speed);
        _fuelreserve = _engine.FuelConsumption(_fuelreserve);
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
        if (!_armor.IsArmorWorking() || _speed < 0)
        {
            return false;
        }

        return true;
    }

    public bool IsjumpEngineInstalled()
    {
        if (_jumpengine.ISSlot())
        {
            return false;
        }

        return true;
    }

    public void StaffAssault()
    {
        _crew ^= true;
    }

    public void ObstructionOfFlight()
    {
        _speed /= _nebulaDamage;
    }

    public void JumpEnginew()
    {
        _range = _jumpengine.Range(_range);
        _gravitonmatter = _jumpengine.FuelConsumption(_gravitonmatter);
    }
}