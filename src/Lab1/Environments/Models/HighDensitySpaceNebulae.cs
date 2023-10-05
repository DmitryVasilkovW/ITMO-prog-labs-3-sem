using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class HighDensitySpaceNebulae : Entities.Environment
{
    private Nebulae _nebulae;
    private AntimatterFlashes _antimatterFlashes;
    private Spaceship.Entities.Spaceship _ship;
    private int _length;
    private int _countOfFirstTypeObstracles;
    private int _countOfSecondTypeObstracles;

    public HighDensitySpaceNebulae(int length, int countOfFirstTypeObstracles, int countOfSecondTypeObstracles,  Spaceship.Entities.Spaceship ship)
        : base(length, countOfFirstTypeObstracles, countOfSecondTypeObstracles, ship)
    {
         _nebulae = new Nebulae();
         _antimatterFlashes = new AntimatterFlashes();
         _ship = ship;
         _countOfFirstTypeObstracles = countOfFirstTypeObstracles;
         _countOfSecondTypeObstracles = countOfSecondTypeObstracles;
         _length = length;
    }

    public new int CountOfSecondTypeObstracles
    {
        get { return _countOfSecondTypeObstracles; }
    }

    public new int Length
    {
        get { return _length; }
    }

    public new bool IsTheShipWasAbleToRemainInService()
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

    public override bool IsCanEnterTheEnvironment()
    {
        if (!_ship.IsjumpEngineInstalled())
        {
            return true;
        }

        return false;
    }

    public void NebulaDamage()
    {
        _ship.Deflector.AsteroidDamage();
    }

    protected new bool IsShipAlive()
    {
        if (_ship.IsShipAlive())
        {
            return true;
        }

        return false;
    }

    protected override void TakingDamageFromAllObstaclesOfTheFirstType()
    {
        while (_countOfFirstTypeObstracles-- > 0)
        {
            if (_ship.Speed > 0)
            {
                _ship = _nebulae.Damage(_ship);
            }
        }
    }

    protected override void TakingDamageFromAllObstaclesOfTheSecondType()
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