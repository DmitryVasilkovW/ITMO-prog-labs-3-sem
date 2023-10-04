namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;

public abstract class Environment : IEnvironment
{
    private IObstacles _firstObstacles;
    private IObstacles _secondObstacles;
    private Spaceship.Entities.Spaceship _ship;
    private string _requiredEngine;
    private int _length;

    protected Environment(IObstacles obstacles, Spaceship.Entities.Spaceship ship, int length)
    {
        _firstObstacles = obstacles;
        _secondObstacles = obstacles;
        _ship = ship;
        _requiredEngine = "tmp";
        _length = length;
    }

    protected Environment(IObstacles firstObstacles, IObstacles secondObstacles, Spaceship.Entities.Spaceship ship, int length)
    {
        _firstObstacles = firstObstacles;
        _secondObstacles = secondObstacles;
        _ship = ship;
        _requiredEngine = "tmp";
        _length = length;
    }

    public int Length
    {
        get { return _length; }
    }

    public virtual bool IsCanEnterTheEnvironment()
    {
        if (_ship.EngineType == _requiredEngine)
        {
            return true;
        }

        return false;
    }
}