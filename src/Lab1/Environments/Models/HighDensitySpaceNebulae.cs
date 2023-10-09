using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class HighDensitySpaceNebulae : IEnvironment
{
    private IList<IList<IObstacle>> _obstracles;
    private ISpaceship _ship;

    public HighDensitySpaceNebulae(int length, IList<IList<IObstacle>> obstracles,  ISpaceship ship)
    {
        _ship = ship;
        Length = length;
        _obstracles = obstracles;
    }

    public int Length { get; }

    public bool IsTheShipWasAbleToRemainInService()
    {
        foreach (IList<IObstacle> listOfObstacles in _obstracles)
        {
            foreach (IObstacle obstacle in listOfObstacles)
            {
                if (!_ship.IsShipAlive())
                {
                    return false;
                }

                _ship = obstacle.Damage(_ship, _ship.Equipment);
            }
        }

        return true;
    }

    public bool IsCanEnterTheEnvironment()
    {
        _ship.JumpEngineWork();
        if (_ship.JumpEngine is not JumpEngineSlot && (Length <= _ship.Range))
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
        foreach (IList<IObstacle> listOfObstacles in _obstracles)
        {
            foreach (IObstacle obstacle in listOfObstacles)
            {
                if (obstacle is IPersonnelDamage)
                {
                    return true;
                }
            }
        }

        return false;
    }
}