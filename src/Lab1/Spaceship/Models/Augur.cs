using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Augur : Entities.Spaceship
{
    private int _speed;
    private int _range;
    private int _fuelreserve;
    private int _gravitonmatter;
    private string _engineType;
    private int _weightDimensionCharacteristics;
    private bool _crew;

    private IEnginesType _engine;
    private IJumpEngine _jumpengine;
    private Deflectors _deflector;
    private Armor _armor;

    public Augur()
    {
        var engine = new ClassEPulseEngine(_weightDimensionCharacteristics);
        var jumpengine = new JumpEngineAlpha(_weightDimensionCharacteristics);
        var deflector = new ThirdClassDeflector(new PhotonDeflectorSlot());
        var armor = new ThirdClassArmor(_weightDimensionCharacteristics);
        string engineType = "PulseEngine";
        int weightDimensionCharacteristics = 3;

        _crew = true;
        _armor = armor;
        _deflector = deflector;
        _jumpengine = jumpengine;
        _engine = engine;
        _engineType = engineType;
        _weightDimensionCharacteristics = weightDimensionCharacteristics;
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

    public new bool IsjumpEngineInstalled()
    {
        if (_jumpengine.ISSlot())
        {
            return false;
        }

        return true;
    }

    public override void Enginew()
    {
        _speed = _engine.Speed(_speed);
        _fuelreserve = _engine.FuelConsumption(_fuelreserve);
    }

    public override void StaffAssault()
    {
        _crew ^= true;
    }

    public override void ObstructionOfFlight(int speedReduction)
    {
        _speed -= speedReduction;
    }

    public override void JumpEnginew()
    {
        _range = _jumpengine.Range(_range);
        _gravitonmatter = _jumpengine.FuelConsumption(_gravitonmatter);
    }
}