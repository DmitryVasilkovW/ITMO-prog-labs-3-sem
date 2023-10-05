namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;

public interface IObstacles
{
    string DamageType { get; }
    Spaceship.Entities.Spaceship Damage(Spaceship.Entities.Spaceship ship);
}