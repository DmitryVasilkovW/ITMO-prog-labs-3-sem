using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class SlowMovingShuttle : ISpaceship
{
    private int _fuelreserve;

    public SlowMovingShuttle()
    {
        WeightDimensionCharacteristics = 1;
        Equipment = new AdditionalSafetyDevicesSlot("none");
        Deflector = new DeflectorSlot(new PhotonDeflectorSlot());
        JumpEngine = new JumpEngineSlot();
        Speed = 10;
        Range = 0;
        Armor = new FirstClassArmor();
        Engine = new ClassCPulseEngine();
    }

    public IJumpEngine JumpEngine { get; }

    public AdditionalSafetyDevices Equipment { get; }

    public Deflectors Deflector { get; }

    public IArmor Armor { get; }

    public int Speed { get; private set; }

    public int Range { get; private set; }

    public IEngine Engine { get; }

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
            Equipment.Effect(Armor, WeightDimensionCharacteristics);
        }
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
        Speed = Engine.Speed(Speed, WeightDimensionCharacteristics);
        _fuelreserve = Engine.FuelConsumption(_fuelreserve, WeightDimensionCharacteristics);
    }

    public void JumpEngineWork()
    {
        Range = JumpEngine.Range(Speed, WeightDimensionCharacteristics);
        _fuelreserve = JumpEngine.FuelConsumption(_fuelreserve, WeightDimensionCharacteristics);
    }
}