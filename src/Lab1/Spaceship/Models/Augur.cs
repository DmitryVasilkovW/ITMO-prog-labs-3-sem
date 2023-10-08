using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Augur : ISpaceship
{
    private int _speed;
    private int _range;
    private int _fuelreserve;
    private int _gravitonmatter;
    private int _weightDimensionCharacteristics;
    private int _nebulaDamage;
    private string _engineType;
    private string _shipName;
    private bool _crew;

    private IJumpEngine _jumpengine;
    private Deflectors _deflector;
    private IArmor _armor;
    private AdditionalSafetyDevices _equipment;

    public Augur(bool whethertoInstallAPhotonicDeflector)
    {
        _weightDimensionCharacteristics = 3;
        _shipName = "Augur";
        _equipment = new AdditionalSafetyDevicesSlot("no protection");
        _nebulaDamage = 923333333;
        _crew = true;
        _speed = 100;
        _range = 100;
        _armor = new ThirdClassArmor(_weightDimensionCharacteristics);
        _jumpengine = new JumpEngineAlpha(_weightDimensionCharacteristics);
        Engine = new ClassEPulseEngine(_weightDimensionCharacteristics);
        _engineType = "PulseEngine";

        if (whethertoInstallAPhotonicDeflector)
        {
            _deflector = new FirstClassDeflector(new StandardPhotonicDeflectors());
        }
        else
        {
            _deflector = new FirstClassDeflector();
        }
    }

    // сделать везде
    public IEnginesType Engine { get; private set; }

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

    public IJumpEngine JumpEngine
    {
        get { return _jumpengine; }
    }

    public int Fuelreserve
    {
        get
        {
            EngineWork();
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

    public void EngineWork()
    {
        _speed = Engine.Speed(_speed);
        _fuelreserve = Engine.FuelConsumption(_fuelreserve);
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