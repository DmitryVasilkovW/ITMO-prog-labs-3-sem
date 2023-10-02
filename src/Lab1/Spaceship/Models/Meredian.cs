using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Meredian : Entities.Spaceship
{
    private int _speed;
    private int _fuelreserve;
    private string _engineType;
    private int _weightDimensionCharacteristics;
    private bool _crew;

    private IEnginesType _engine;
    private Deflectors _deflector;
    private Armor _armor;
    private AdditionalSafetyDevices _equipment;

    public Meredian()
    {
        var engine = new ClassEPulseEngine();
        var deflector = new SecondClassDeflector(new PhotonDeflectorSlot());
        var armor = new SecondClassArmor();
        var equipment = new AntiNitrinoEmitter("SpaceWhale");
        string engineType = "PulseEngine";
        int weightDimensionCharacteristics = 241;

        _equipment = equipment;
        _armor = armor;
        _deflector = deflector;
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
}