using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class NormalSpace : Entities.IEnvironment
{
    private Asteroid _asteroid;
    private Meteorites _meteorites;
    private ISpaceship _ship;
    private int _countOfFirstTypeObstracles;
    private int _countOfSecondTypeObstracles;

    public NormalSpace(int length, int countOfFirstTypeObstracles, int countOfSecondTypeObstracles, ISpaceship ship)
    {
        _asteroid = new Asteroid();
        _meteorites = new Meteorites();
        _ship = ship;
        _countOfFirstTypeObstracles = countOfFirstTypeObstracles;
        _countOfSecondTypeObstracles = countOfSecondTypeObstracles;
        Length = length;
    }

    public int CountOfSecondTypeObstracles { get; }

    public int Length { get; }

    public string FirstTypeObstracleType
    {
        get { return _asteroid.DamageType; }
    }

    public string SecondTypeObstracleType
    {
        get { return _meteorites.DamageType; }
    }

    public int CountOfFirstTypeObstracles { get; }

    public bool IsTheShipWasAbleToRemainInService()
    {
        TakingDamageFromAllObstaclesOfTheFirstType();

        if (!IsShipAlive())
        {
            return false;
        }

        TakingDamageFromAllObstaclesOfTheSecondType();

        if (!IsShipAlive())
        {
            return false;
        }

        return true;
    }

    public bool IsCanEnterTheEnvironment()
    {
        if (_ship.Engine is IEngine)
        {
            return true;
        }

        return false;
    }

    public bool IsShipAlive()
    {
        if (_ship.IsShipAlive())
        {
            return true;
        }

        return false;
    }

    public void TakingDamageFromAllObstaclesOfTheFirstType()
    {
        while (_countOfFirstTypeObstracles-- > 0)
        {
            _ship = _asteroid.Damage(_ship);
        }
    }

    public void TakingDamageFromAllObstaclesOfTheSecondType()
    {
        while (_countOfSecondTypeObstracles-- > 0)
        {
            _ship = _meteorites.Damage(_ship);
        }
    }

    public bool IsObstaclesKillStaff()
    {
        return false;
    }
}