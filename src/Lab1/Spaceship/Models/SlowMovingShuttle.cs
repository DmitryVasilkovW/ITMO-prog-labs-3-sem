using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class SlowMovingShuttle : ISpaceship
{
    private int _fuelreserve;
    private int _gravitonmatter;
    private int _nebulaDamage;
    private int _range;

    public SlowMovingShuttle()
    {
        WeightDimensionCharacteristics = 1;
        Equipment = new AdditionalSafetyDevicesSlot("none");
        Deflector = new DeflectorSlot(new PhotonDeflectorSlot());
        _nebulaDamage = 1000;
        JumpEngine = new JumpEngineSlot();
        Speed = 100;
        _range = 0;
        Armor = new FirstClassArmor(WeightDimensionCharacteristics);
        Engine = new ClassCPulseEngine();
    }

    public bool IsPhotonDeflectorWorking
    {
        get { return Deflector.IsaPhotonDeflectorInstalled; }
    }

    public IJumpEngine JumpEngine { get; }

    public AdditionalSafetyDevices Equipment { get; }

    public Deflectors Deflector { get; }

    public IArmor Armor { get; }

    public int Speed { get; private set; }

    public IEnginesType Engine { get; }

    public int WeightDimensionCharacteristics { get; }

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
            _range = JumpEngine.Range(_range, WeightDimensionCharacteristics);
            _gravitonmatter = JumpEngine.FuelConsumption(_gravitonmatter, WeightDimensionCharacteristics);
        }
        else
        {
            Speed = Engine.Speed(Speed, WeightDimensionCharacteristics);
            _fuelreserve = Engine.FuelConsumption(_fuelreserve, WeightDimensionCharacteristics);
        }
    }

    public void ObstructionOfFlight()
    {
        Speed -= _nebulaDamage;
    }
}