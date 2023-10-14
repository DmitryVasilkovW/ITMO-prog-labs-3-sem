namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

public interface IArmor
{
    bool IsArmorWorking();

    void AsteroidDamage(int weightDimensionsOfTheShip);

    void MeteoriteDamage(int weightDimensionsOfTheShip);

    void SpaceWhaleDamage(int weightDimensionsOfTheShip);

    void SavingStatusOfTheArmor(int weightDimensionsOfTheShip, AdditionalSafetyDevices device);
}