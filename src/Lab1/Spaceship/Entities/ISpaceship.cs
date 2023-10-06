namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

public interface ISpaceship
{
    string ShipName { get; }

    // bool IsDeflectorWorking { get; }
    bool IsPhotonDeflectorWorking { get; }
    int Speed { get; }

    IEnginesType Engine { get; }

    IJumpEngine JumpEngine { get; }

    Deflectors Deflector { get; }

    IArmor Armor { get; }
    AdditionalSafetyDevices Equipment { get; }

    int WeightDimensionCharacteristics { get; }

    string EngineType { get; }
    bool IsDeflectorWorking { get; }

    int Fuelreserve { get; }

    bool IsjumpEngineInstalled();

    bool IsShipAlive();

    void Enginew();

    void StaffAssault();

    // сделать это в кораблях
    bool IsTheStaffAlive();

    void SafetyEquipmentOperation();

    void ObstructionOfFlight();

    void JumpEnginew();
}