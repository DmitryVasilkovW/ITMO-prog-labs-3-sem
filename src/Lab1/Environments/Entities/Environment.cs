using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;

public abstract class Environment : IEnvironment
{
    private IObstacles _firstObstacles;
    private IObstacles _secondObstacles;
    private Spaceship.Entities.Spaceship _ship;
    private string _requiredEngine;
    private int _length;
    private int _countOfFirstTypeObstracles;
    private int _countOfSecondTypeObstracles;

    protected Environment(IObstacles obstacles, Spaceship.Entities.Spaceship ship, int length, int countOfFirstTypeObstracles, int countOfSecondTypeObstracles)
    {
        _countOfFirstTypeObstracles = countOfFirstTypeObstracles;
        _countOfSecondTypeObstracles = countOfSecondTypeObstracles;
        _firstObstacles = obstacles;
        _secondObstacles = obstacles;
        _ship = ship;
        _requiredEngine = "tmp";
        _length = length;
    }

    protected Environment(IObstacles firstObstacles, IObstacles secondObstacles, Spaceship.Entities.Spaceship ship, int length, int countOfFirstTypeObstracles, int countOfSecondTypeObstracles)
    {
        _countOfFirstTypeObstracles = countOfFirstTypeObstracles;
        _countOfSecondTypeObstracles = countOfSecondTypeObstracles;
        _firstObstacles = firstObstacles;
        _secondObstacles = secondObstacles;
        _ship = ship;
        _requiredEngine = "tmp";
        _length = length;
    }

    protected Environment(int length, int countOfFirstTypeObstracles, int countOfSecondTypeObstracles, Spaceship.Entities.Spaceship ship)
    {
        _countOfFirstTypeObstracles = countOfFirstTypeObstracles;
        _countOfSecondTypeObstracles = countOfSecondTypeObstracles;
        _firstObstacles = new Asteroid();
        _secondObstacles = _firstObstacles;
        _ship = ship;
        _requiredEngine = "tmp";
        _length = length;
    }

    public int CountOfFirstTypeObstracles
    {
        get { return _countOfFirstTypeObstracles; }
    }

    public int CountOfSecondTypeObstracles
    {
        get { return _countOfSecondTypeObstracles; }
    }

    public int Length
    {
        get { return _length; }
    }

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

    // проверить
    public virtual bool IsCanEnterTheEnvironment()
    {
        if (_ship.EngineType == _requiredEngine)
        {
            return true;
        }

        return false;
    }

    protected bool IsShipAlive()
    {
        if (_ship.IsShipAlive())
        {
            return true;
        }

        return false;
    }

    protected abstract void TakingDamageFromAllObstaclesOfTheFirstType();

    protected abstract void TakingDamageFromAllObstaclesOfTheSecondType();
}