namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;

public interface IObstacles
{
    string DamageType { get; }
    Spaceship.Entities.ISpaceship Damage(Spaceship.Entities.ISpaceship ship);
}