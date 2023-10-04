using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Vaklas : Entities.Spaceship
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
    private Armor _armor;

    public Vaklas(bool whethertoInstallAPhotonicDeflector)
        : base(whethertoInstallAPhotonicDeflector)
    {
        var engine = new ClassEPulseEngine(_weightDimensionCharacteristics);
        var jumpengine = new JumpEngineGamma(_weightDimensionCharacteristics);
        var deflector = new FirstClassDeflector(new PhotonDeflectorSlot());
        var armor = new SecondClassArmor(_weightDimensionCharacteristics);
        string engineType = "PulseEngine";
        int weightDimensionCharacteristics = 2;

        _nebulaDamage = 1000;
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

    public new IEnginesType Engine
    {
        get { return _engine; }
    }

    public new IJumpEngine JumpEngine
    {
        get { return _jumpengine; }
    }

    public new Deflectors Deflector
    {
        get { return _deflector; }
    }

    public new Armor Armor
    {
        get { return _armor; }
    }

    public override int WeightDimensionCharacteristics
    {
        get { return _weightDimensionCharacteristics; }
    }

    public override string EngineType
    {
        get { return _engineType; }
    }

    public override void Enginew()
    {
        _speed = _engine.Speed(_speed);
        _fuelreserve = _engine.FuelConsumption(_fuelreserve);
    }

    public new bool IsTheStaffAlive()
    {
        if (_crew)
        {
            return true;
        }

        return false;
    }

    public new bool IsjumpEngineInstalled()
    {
        if (_jumpengine.ISSlot())
        {
            return false;
        }

        return true;
    }

    public override void StaffAssault()
    {
        _crew ^= true;
    }

    public new void ObstructionOfFlight()
    {
        _speed -= _nebulaDamage;
    }

    public override void JumpEnginew()
    {
        _range = _jumpengine.Range(_range);
        _gravitonmatter = _jumpengine.FuelConsumption(_gravitonmatter);
    }
}