using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class HighDensitySpaceNebulae : Entities.IEnvironment
{
    private AntimatterFlashes _antimatterFlashes;
    private Spaceship.Entities.ISpaceship _ship;
    private int _countOfSecondTypeObstracles;

    public HighDensitySpaceNebulae(int length, int countOfSecondTypeObstracles,  Spaceship.Entities.ISpaceship ship)
    {
        _antimatterFlashes = new AntimatterFlashes();
        _ship = ship;
        _countOfSecondTypeObstracles = countOfSecondTypeObstracles;
        Length = length;
    }

    public int CountOfFirstTypeObstracles { get; }

    public int CountOfSecondTypeObstracles
    {
        get { return _countOfSecondTypeObstracles; }
    }

    public int Length { get; }

    public string SecondTypeObstracleType
    {
        get { return _antimatterFlashes.DamageType; }
    }

    public bool IsTheShipWasAbleToRemainInService()
    {
        if (!_ship.IsShipAlive())
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
        if (!_ship.JumpEngine.ISSlot())
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
        if (_countOfSecondTypeObstracles > 0)
        {
            return true;
        }

        return false;
    }

    public void TakingDamageFromAllObstaclesOfTheSecondType()
    {
        while (_countOfSecondTypeObstracles-- > 0)
        {
            if (_ship.IsShipAlive())
            {
                _ship = _antimatterFlashes.Damage(_ship);
            }
        }
    }
}