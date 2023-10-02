using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class NormalSpace : Entities.Environment
{
    private Asteroid _asteroid;
    private Meteorites _meteorites;
    private Spaceship.Entities.Spaceship _ship;

    public NormalSpace(Asteroid firstObstacles, Meteorites secondObstacles, Spaceship.Entities.Spaceship ship)
        : base(firstObstacles, secondObstacles, ship)
    {
        _asteroid = firstObstacles;
        _meteorites = secondObstacles;
        _ship = ship;
        RequiredEngine = "PulseEngine";
    }

    public void AsteroidDamage()
    {
        _asteroid.Damage(_ship);
    }

    public void MeteoriteDamage()
    {
        _meteorites.Damage(_ship);
    }
}