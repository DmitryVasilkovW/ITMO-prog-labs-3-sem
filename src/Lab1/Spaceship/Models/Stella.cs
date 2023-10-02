using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Stella : Entities.Spaceship
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

    public Stella()
    {
        var engine = new ClassCPulseEngine();
        var jumpengine = new JumpEngineOmega();
        var deflector = new FirstClassDeflector(new PhotonDeflectorSlot());
        var armor = new FirstClassArmor();
        string engineType = "Jumpengine";
        int weightDimensionCharacteristics = 241;

        _armor = armor;
        _deflector = deflector;
        _jumpengine = jumpengine;
        _engine = engine;
        _engineType = engineType;
        _weightDimensionCharacteristics = weightDimensionCharacteristics;
    }

    public override int WeightDimensionCharacteristics
    {
        get { return _weightDimensionCharacteristics; }
    }

    public override string EngineType
    {
        get { return _engineType; }
    }

    public override void Engine()
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

    public override void JumpEngine()
    {
        _range = _jumpengine.Range(_range);
        _gravitonmatter = _jumpengine.FuelConsumption(_gravitonmatter);
    }
}