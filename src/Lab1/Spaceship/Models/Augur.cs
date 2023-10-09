using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Augur : ISpaceship
{
    private int _range;
    private int _fuelreserve;
    private int _gravitonmatter;

    public Augur(bool whethertoInstallAPhotonicDeflector)
    {
        WeightDimensionCharacteristics = 3;
        Equipment = new AdditionalSafetyDevicesSlot("no protection");
        Speed = 10;
        _range = 100;
        Armor = new ThirdClassArmor();
        JumpEngine = new JumpEngineAlpha();
        Engine = new ClassEPulseEngine();

        if (whethertoInstallAPhotonicDeflector)
        {
            Deflector = new FirstClassDeflector(new StandardPhotonicDeflectors());
        }
        else
        {
            Deflector = new FirstClassDeflector();
        }
    }

    public IEngine Engine { get; private set; }

    public bool IsPhotonDeflectorWorking
    {
        get { return Deflector.IsaPhotonDeflectorInstalled; }
    }

    public int Speed { get; private set; }

    public IJumpEngine JumpEngine { get; }

    public int Fuelreserve
    {
        get
        {
            return _fuelreserve;
        }
    }

    public Deflectors Deflector { get; }

    public IArmor Armor { get; }

    public AdditionalSafetyDevices Equipment { get; }

    public int WeightDimensionCharacteristics { get; }

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
            Equipment.Effect(Armor, WeightDimensionCharacteristics);
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
        if (JumpEngine is not JumpEngineSlot)
        {
            _range = JumpEngine.Range(_range, WeightDimensionCharacteristics);
            _fuelreserve = Engine.FuelConsumption(_fuelreserve, WeightDimensionCharacteristics);
        }
        else
        {
            Speed = Engine.Speed(Speed, WeightDimensionCharacteristics);
            _fuelreserve = Engine.FuelConsumption(_fuelreserve, WeightDimensionCharacteristics);
        }
    }

    public void JumpEnginew()
    {
        _range = JumpEngine.Range(Speed, WeightDimensionCharacteristics);
        _gravitonmatter = JumpEngine.FuelConsumption(_gravitonmatter, WeightDimensionCharacteristics);
    }
}