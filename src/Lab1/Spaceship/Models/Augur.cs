using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Augur : Entities.ISpaceship
{
    private int _speed;
    private int _range;
    private int _fuelreserve;
    private int _gravitonmatter;
    private string _engineType;
    private int _weightDimensionCharacteristics;
    private bool _crew;
    private int _nebulaDamage;

    private IEnginesType _engine;
    private IJumpEngine _jumpengine;
    private Deflectors _deflector;
    private IArmor _armor;
    private AdditionalSafetyDevices _equipment;
    private string _shipName;

    public Augur(bool whethertoInstallAPhotonicDeflector)
    {
        var engine = new ClassEPulseEngine(3);
        var jumpengine = new JumpEngineAlpha(3);
        var deflector = new ThirdClassDeflector(new PhotonDeflectorSlot());
        var armor = new ThirdClassArmor(3);
        string engineType = "PulseEngine";
        int weightDimensionCharacteristics = 3;

        _shipName = "Augur";
        _equipment = new AdditionalSafetyDevicesSlot("no protection");
        _nebulaDamage = 923333333;
        _crew = true;
        _speed = 100;
        _armor = armor;
        _deflector = deflector;
        _jumpengine = jumpengine;
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

    public int Fuelreserve
    {
        get
        {
            Enginew();
            return _fuelreserve;
        }
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

    public bool IsTheStaffAlive()
    {
        if (_crew)
        {
            return true;
        }

        return false;
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