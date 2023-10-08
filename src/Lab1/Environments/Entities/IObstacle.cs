namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;

public interface IObstacle
{
    string DamageType { get; }
    Spaceship.Entities.ISpaceship Damage(Spaceship.Entities.ISpaceship ship);
}