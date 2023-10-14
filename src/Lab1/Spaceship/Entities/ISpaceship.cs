using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;

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

    void ProtectionFromObstacles(IObstacle obstacle);

    bool IsShipAlive();

    void EngineWork();

    void JumpEngineWork();

    void SafetyEquipmentOperation();
}