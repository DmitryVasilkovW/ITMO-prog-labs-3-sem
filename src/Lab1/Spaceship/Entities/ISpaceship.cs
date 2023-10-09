namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

public interface ISpaceship
{
    int Speed { get; }

    int Range { get; }

    IEngine Engine { get; }

    IJumpEngine JumpEngine { get; }

    Deflectors Deflector { get; }

    IArmor Armor { get; }
    AdditionalSafetyDevices Equipment { get; }

    int WeightDimensionCharacteristics { get; }

    int Fuelreserve { get; }

    bool IsShipAlive();

    void EngineWork();

    void JumpEngineWork();

    void SafetyEquipmentOperation();
}