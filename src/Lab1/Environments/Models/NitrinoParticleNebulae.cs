using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class NitrinoParticleNebulae : Entities.IEnvironment
{
    private SpaceWhale _spaceWhale;
    private ISpaceship _ship;
    private int _countOfFirstTypeObstracles;

    public NitrinoParticleNebulae(int length, int countOfFirstTypeObstracles, ISpaceship ship)
    {
        _spaceWhale = new SpaceWhale();
        _ship = ship;
        _countOfFirstTypeObstracles = countOfFirstTypeObstracles;

        Length = length;
    }

    public int CountOfSecondTypeObstracles { get; }
    public int Length { get; }

    public string SecondTypeObstracleType
    {
        get { return _spaceWhale.DamageType; }
    }

    public int CountOfFirstTypeObstracles { get; }

    public bool IsTheShipWasAbleToRemainInService()
    {
        TakingDamageFromAllObstaclesOfTheFirstType();

        if (!IsShipAlive())
        {
            return false;
        }

        return true;
    }

    public bool IsCanEnterTheEnvironment()
    {
        if (_ship.Engine is IEngine && _ship.Engine is IExponentialAcceleration)
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

    public bool IsObstaclesKillStaff()
    {
        return false;
    }

    private void TakingDamageFromAllObstaclesOfTheFirstType()
    {
        while (_countOfFirstTypeObstracles-- > 0)
        {
            if (_ship.IsShipAlive())
            {
                _ship = _spaceWhale.Damage(_ship);
            }
        }
    }
}