using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class HighDensitySpaceNebulae : Entities.IEnvironment
{
    private Nebulae _nebulae;
    private AntimatterFlashes _antimatterFlashes;
    private Spaceship.Entities.ISpaceship _ship;
    private int _countOfFirstTypeObstracles;
    private int _countOfSecondTypeObstracles;

    public HighDensitySpaceNebulae(int length, int countOfFirstTypeObstracles, int countOfSecondTypeObstracles,  Spaceship.Entities.ISpaceship ship)
    {
         _nebulae = new Nebulae();
         _antimatterFlashes = new AntimatterFlashes();
         _ship = ship;
         _countOfFirstTypeObstracles = countOfFirstTypeObstracles;
         _countOfSecondTypeObstracles = countOfSecondTypeObstracles;
         Length = length;
    }

    public int CountOfFirstTypeObstracles { get; }

    public int CountOfSecondTypeObstracles
    {
        get { return _countOfSecondTypeObstracles; }
    }

    public int Length { get; }

    public string FirstTypeObstracleType
    {
        get { return _nebulae.DamageType; }
    }

    public string SecondTypeObstracleType
    {
        get { return _antimatterFlashes.DamageType; }
    }

    public bool IsTheShipWasAbleToRemainInService()
    {
        _ship.EngineWork();
        TakingDamageFromAllObstaclesOfTheFirstType();

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
        if (_ship.IsjumpEngineInstalled())
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
            if (_ship.Speed > 0)
            {
                _ship = _nebulae.Damage(_ship);
            }
        }
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