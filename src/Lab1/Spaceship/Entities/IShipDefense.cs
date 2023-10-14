namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

public interface IShipDefense
{
    void AsteroidDamage();

    void MeteoriteDamage();

    void SpaceWhaleDamage();

    bool IsWorking();
}