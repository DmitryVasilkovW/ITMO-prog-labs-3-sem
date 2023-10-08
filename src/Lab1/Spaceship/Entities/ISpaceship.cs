namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

public interface ISpaceship
{
    int Speed { get; }

    IEnginesType Engine { get; }

    IJumpEngine JumpEngine { get; }

    Deflectors Deflector { get; }

    IArmor Armor { get; }
    AdditionalSafetyDevices Equipment { get; }

    int Fuelreserve { get; }

    bool IsjumpEngineInstalled();

    bool IsShipAlive();

    void EngineWork();

    void SafetyEquipmentOperation();

    void ObstructionOfFlight();
}