using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class SlowMovingShuttle : Entities.ISpaceship
{
    private int _speed;
    private int _fuelreserve;
    private int _gravitonmatter;
    private int _nebulaDamage;
    private int _range;
    private bool _crew;

    public SlowMovingShuttle()
    {
        WeightDimensionCharacteristics = 1;
        Equipment = new AdditionalSafetyDevicesSlot("none");
        Deflector = new DeflectorSlot(new PhotonDeflectorSlot());
        ShipName = "SlowMovingShuttle";
        _nebulaDamage = 1000;
        JumpEngine = new JumpEngineSlot();
        Speed = 100;
        _range = 0;
        Armor = new FirstClassArmor(WeightDimensionCharacteristics);
        Engine = new ClassCPulseEngine(WeightDimensionCharacteristics);
        EngineType = "PulseEngine";
    }

    public bool IsPhotonDeflectorWorking
    {
        get { return Deflector.IsaPhotonDeflectorInstalled; }
    }

    public IJumpEngine JumpEngine { get; }

    public AdditionalSafetyDevices Equipment { get; }

    public Deflectors Deflector { get; }

    public IArmor Armor { get; }

    public int Speed { get; }

    public string ShipName { get; }

    public IEnginesType Engine { get; }

    public int WeightDimensionCharacteristics { get; }

    public string EngineType { get; }

    public bool IsDeflectorWorking
    {
        get { return Deflector.IsDeflectorWorking(); }
    }

    public int Fuelreserve
    {
        get
        {
            EngineWork();
            return _fuelreserve;
        }
    }

    public void SafetyEquipmentOperation()
    {
        if (Deflector.IsDeflectorWorking())
        {
            Equipment.Effect(Deflector);
        }
        else
        {
            Equipment.Effect(Armor);
        }
    }

    public bool IsjumpEngineInstalled()
    {
        if (JumpEngine.ISSlot())
        {
            return false;
        }

        return true;
    }

    public bool IsShipAlive()
    {
        if (Armor.IsArmorWorking())
        {
            return true;
        }

        return false;
    }

    public void EngineWork()
    {
        if (JumpEngine is not JumpEngineSlot)
        {
            _range = JumpEngine.Range(_range);
            _gravitonmatter = JumpEngine.FuelConsumption(_gravitonmatter);
        }
        else
        {
            _speed = Engine.Speed(_speed);
            _fuelreserve = Engine.FuelConsumption(_fuelreserve);
        }
    }

    public void StaffAssault()
    {
        _crew ^= true;
    }

    public void ObstructionOfFlight()
    {
        _speed -= _nebulaDamage;
    }
}