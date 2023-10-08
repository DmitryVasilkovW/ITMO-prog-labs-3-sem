using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Stella : Entities.ISpaceship
{
    private int _range;
    private int _fuelreserve;
    private int _gravitonmatter;
    private int _nebulaDamage;

    public Stella(bool whethertoInstallAPhotonicDeflector)
    {
        WeightDimensionCharacteristics = 1;
        Equipment = new AdditionalSafetyDevicesSlot("none");
        ShipName = "Stella";
        _nebulaDamage = 1000;
        Speed = 100;
        _range = 100;
        Armor = new FirstClassArmor(WeightDimensionCharacteristics);
        JumpEngine = new JumpEngineOmega(WeightDimensionCharacteristics);
        Engine = new ClassCPulseEngine(WeightDimensionCharacteristics);
        EngineType = "Jumpengine";

        if (whethertoInstallAPhotonicDeflector)
        {
            Deflector = new FirstClassDeflector(new StandardPhotonicDeflectors());
        }
        else
        {
            Deflector = new FirstClassDeflector();
        }
    }

    public bool IsPhotonDeflectorWorking { get; }

    public int Speed { get; private set; }

    public int Fuelreserve
    {
        get
        {
            EngineWork();
            return _fuelreserve;
        }
    }

    public string ShipName { get; }

    public IEnginesType Engine { get; }

    public IJumpEngine JumpEngine { get; }

    public Deflectors Deflector { get; }

    public IArmor Armor { get; }

    public AdditionalSafetyDevices Equipment { get; }

    public int WeightDimensionCharacteristics { get; }

    public string EngineType { get; }

    public bool IsDeflectorWorking
    {
        get { return Deflector.IsDeflectorWorking(); }
    }

    public bool IsjumpEngineInstalled()
    {
        if (JumpEngine.ISSlot())
        {
            return false;
        }

        return true;
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

    public bool IsShipAlive()
    {
        if (Armor.IsArmorWorking() || Deflector.IsDeflectorWorking())
        {
            return true;
        }

        return false;
    }

    public void EngineWork()
    {
        Speed = Engine.Speed(Speed);
        _fuelreserve = Engine.FuelConsumption(_fuelreserve);
    }

    public void ObstructionOfFlight()
    {
        Speed -= _nebulaDamage;
    }

    public void JumpEnginew()
    {
        _range = JumpEngine.Range(_range);
        _gravitonmatter = JumpEngine.FuelConsumption(_gravitonmatter);
    }
}