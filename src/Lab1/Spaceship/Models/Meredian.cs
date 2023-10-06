using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Meredian : Entities.ISpaceship
{
    private int _speed;
    private int _fuelreserve;
    private int _weightDimensionCharacteristics;
    private int _gravitonmatter;
    private int _range;
    private int _nebulaDamage;
    private bool _crew;
    private string _engineType;
    private string _shipName;

    private IEnginesType _engine;
    private IJumpEngine _jumpengine;
    private Deflectors _deflector;
    private IArmor _armor;
    private AdditionalSafetyDevices _equipment;

    public Meredian(bool whethertoInstallAPhotonicDeflector)
    {
        _weightDimensionCharacteristics = 2;
        _range = 100;
        _shipName = "Meredian";
        _speed = 100;
        _nebulaDamage = 1000;
        _jumpengine = new JumpEngineSlot();
        _equipment = new AntiNitrinoEmitter("SpaceWhale");
        _armor = new SecondClassArmor(_weightDimensionCharacteristics);
        _deflector = new SecondClassDeflector(new PhotonDeflectorSlot());
        _engine = new ClassEPulseEngine(_weightDimensionCharacteristics);
        _engineType = "PulseEngine";

        if (whethertoInstallAPhotonicDeflector)
        {
            _deflector.PhotonDeflectorInstallation(new StandardPhotonicDeflectors());
        }
    }

    public bool IsPhotonDeflectorWorking
    {
        get { return _deflector.IsaPhotonDeflectorInstalled; }
    }

    public Deflectors Deflector
    {
        get { return _deflector; }
    }

    public bool IsDeflectorWorking
    {
        get { return _deflector.IsDeflectorWorking(); }
    }

    public int Fuelreserve
    {
        get
        {
            Enginew();
            return _fuelreserve;
        }
    }

    public IArmor Armor
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

    public IJumpEngine JumpEngine
    {
        get { return _jumpengine; }
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
        if (_armor.IsArmorWorking() || _deflector.IsDeflectorWorking())
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
        _speed -= _nebulaDamage;
    }

    public void JumpEnginew()
    {
        _range = _jumpengine.Range(_speed);
        _gravitonmatter = _jumpengine.FuelConsumption(_gravitonmatter);
    }
}