namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

public interface IArmor
{
    bool IsArmorWorking();

    void AsteroidDamage();

    void MeteoriteDamage();

    void SpaceWhaleDamage();

    void SavingStatusOfTheArmor(string damagetype);
}