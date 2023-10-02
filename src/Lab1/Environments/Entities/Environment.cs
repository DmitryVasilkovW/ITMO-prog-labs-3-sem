namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;

public abstract class Environment : IEnvironment
{
    private IObstacles _firstObstacles;
    private IObstacles _secondObstacles;
    private Spaceship.Entities.Spaceship _ship;
    private string _requiredEngine;

    protected Environment(IObstacles obstacles, Spaceship.Entities.Spaceship ship)
    {
        _firstObstacles = obstacles;
        _secondObstacles = obstacles;
        _ship = ship;
        _requiredEngine = "tmp";
    }

    protected Environment(IObstacles firstObstacles, IObstacles secondObstacles, Spaceship.Entities.Spaceship ship)
    {
        _firstObstacles = firstObstacles;
        _secondObstacles = secondObstacles;
        _ship = ship;
        _requiredEngine = "tmp";
    }

    protected string RequiredEngine
    {
        get { return _requiredEngine; }
        set { _requiredEngine = value; }
    }

    public bool IsEngineQualified()
    {
        if (_ship.EngineType == _requiredEngine)
        {
            return true;
        }

        return false;
    }
}