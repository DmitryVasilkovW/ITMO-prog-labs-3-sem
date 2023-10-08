using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Vaklas : ISpaceship
{
    private int _range;
    private int _fuelreserve;
    private int _gravitonmatter;
    private int _nebulaDamage;

    public Vaklas(bool whethertoInstallAPhotonicDeflector)
    {
        WeightDimensionCharacteristics = 2;
        Equipment = new AdditionalSafetyDevicesSlot("none");
        ShipName = "Vaklas";
        Speed = 100;
        _nebulaDamage = 923333333;
        Armor = new SecondClassArmor(WeightDimensionCharacteristics);
        JumpEngine = new JumpEngineGamma(WeightDimensionCharacteristics);
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

    public bool IsPhotonDeflectorWorking
    {
        get { return Deflector.IsaPhotonDeflectorInstalled; }
    }

    public string ShipName { get; }
    public int Speed { get; private set; }

    public IEnginesType Engine { get; }

    public IJumpEngine JumpEngine { get; }

    public Deflectors Deflector { get; }

    public IArmor Armor { get; }

    public int WeightDimensionCharacteristics { get; }

    public string EngineType { get; }

    public AdditionalSafetyDevices Equipment { get; }

    public int Fuelreserve
    {
        get
        {
            EngineWork();
            return _fuelreserve;
        }
    }

    public bool IsDeflectorWorking
    {
        get { return Deflector.IsDeflectorWorking(); }
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
            Speed = Engine.Speed(Speed);
            _fuelreserve = Engine.FuelConsumption(_fuelreserve);
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

    public bool IsShipAlive()
    {
        if (!Armor.IsArmorWorking())
        {
            return false;
        }

        return true;
    }

    public bool IsjumpEngineInstalled()
    {
        if (JumpEngine.ISSlot())
        {
            return false;
        }

        return true;
    }

    public void ObstructionOfFlight()
    {
        Speed /= _nebulaDamage;
    }
}