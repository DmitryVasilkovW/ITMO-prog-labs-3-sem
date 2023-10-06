using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Meredian : Entities.ISpaceship
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
    private string _shipName;
    private int _gravitonmatter;
    private int _range;

    public Meredian(bool whethertoInstallAPhotonicDeflector)
    {
        var engine = new ClassEPulseEngine(2);
        var deflector = new SecondClassDeflector(new PhotonDeflectorSlot());
        var armor = new SecondClassArmor(2);
        var equipment = new AntiNitrinoEmitter("SpaceWhale");
        var jumpEngine = new JumpEngineSlot();
        string engineType = "PulseEngine";
        int weightDimensionCharacteristics = 2;

        _range = 100;
        _shipName = "Meredian";
        _speed = 100;
        _nebulaDamage = 1000;
        _jumpengine = jumpEngine;
        _equipment = equipment;
        _armor = armor;
        _deflector = deflector;
        _engine = engine;
        _engineType = engineType;
        _weightDimensionCharacteristics = weightDimensionCharacteristics;

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