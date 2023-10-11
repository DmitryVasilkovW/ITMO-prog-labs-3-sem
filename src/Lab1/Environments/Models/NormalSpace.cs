using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class NormalSpace : IEnvironment
{
    private IList<INormalSpace> _obstacles;

    public NormalSpace(int length, IList<INormalSpace> obstacles)
    {
        _obstacles = obstacles;
        Length = length;
    }

    public int Length { get; }

    public bool IsTheShipWasAbleToRemainInService(ISpaceship ship)
    {
        foreach (IObstacle obstacle in _obstacles)
        {
            if (!ship.IsShipAlive())
            {
                return false;
            }

            obstacle.Damage(ship);
        }

        return true;
    }

    public bool IsCanEnterTheEnvironment(ISpaceship ship)
    {
        ship.EngineWork();
        if (ship.Engine is IEngine && (Length <= ship.Speed))
        {
            return true;
        }

        return false;
    }

    public bool IsObstaclesKillStaff()
    {
        foreach (IObstacle obstacle in _obstacles)
        {
            if (obstacle is IPersonnelDamage)
            {
                return true;
            }
        }

        return false;
    }
}