using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Augur : ISpaceship
{
    private int _range;
    private int _fuelreserve;
    private int _gravitonmatter;
    private int _nebulaDamage;

    public Augur(bool whethertoInstallAPhotonicDeflector)
    {
        WeightDimensionCharacteristics = 3;
        ShipName = "Augur";
        Equipment = new AdditionalSafetyDevicesSlot("no protection");
        _nebulaDamage = 923333333;
        Speed = 100;
        _range = 100;
        Armor = new ThirdClassArmor(WeightDimensionCharacteristics);
        JumpEngine = new JumpEngineAlpha(WeightDimensionCharacteristics);
        Engine = new ClassEPulseEngine(WeightDimensionCharacteristics);
        EngineType = "PulseEngine";

        if (whethertoInstallAPhotonicDeflector)
        {
            Deflector = new FirstClassDeflector(new StandardPhotonicDeflectors());
        }
        else
        {
            Deflector = new FirstClassDeflector();
        }
    }

    public IEnginesType Engine { get; private set; }

    public bool IsPhotonDeflectorWorking
    {
        get { return Deflector.IsaPhotonDeflectorInstalled; }
    }

    public int Speed { get; private set; }

    public string ShipName { get; }

    public IJumpEngine JumpEngine { get; }

    public int Fuelreserve
    {
        get
        {
            EngineWork();
            return _fuelreserve;
        }
    }

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
        if ((Armor.IsArmorWorking() || Deflector.IsDeflectorWorking()) && Speed > 0)
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
        _range = JumpEngine.Range(Speed);
        _gravitonmatter = JumpEngine.FuelConsumption(_gravitonmatter);
    }
}