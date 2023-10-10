using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class SlowMovingShuttle : ISpaceship
{
    private const int InitialSpeed = 100;
    private const int InitialRange = 0;
    private const int InitialFuelreserve = 1;
    private const int InitialWeightDimensionCharacteristics = 1;
    public SlowMovingShuttle()
    {
        WeightDimensionCharacteristics = InitialWeightDimensionCharacteristics;
        Equipment = new AdditionalSafetyDevicesSlot();
        Deflector = new DeflectorSlot(new PhotonDeflectorSlot());
        JumpEngine = new JumpEngineSlot();
        Speed = InitialSpeed;
        Range = InitialRange;
        Fuelreserve = InitialFuelreserve;
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

    public int Fuelreserve { get; private set; }

    public void SafetyEquipmentOperation()
    {
        if (Deflector.IsDeflectorWorking())
        {
            Equipment.Effect(Deflector, Equipment);
        }
        else
        {
            Equipment.Effect(Armor, WeightDimensionCharacteristics, Equipment);
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
        Fuelreserve = Engine.FuelConsumption(Fuelreserve, WeightDimensionCharacteristics);
    }

    public void JumpEngineWork()
    {
        Range = JumpEngine.Range(Speed, WeightDimensionCharacteristics);
        Fuelreserve = JumpEngine.FuelConsumption(Fuelreserve, WeightDimensionCharacteristics);
    }
}