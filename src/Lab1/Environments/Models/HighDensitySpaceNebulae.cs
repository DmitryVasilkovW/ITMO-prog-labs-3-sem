using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class HighDensitySpaceNebulae : IEnvironment
{
    private IList<IObstacle> _obstacles;

    public HighDensitySpaceNebulae(int length, IList<IObstacle> obstacles)
    {
        Length = length;
        _obstacles = obstacles;

        foreach (IObstacle obstacle in obstacles)
        {
            if (obstacle is not IHighDensitySpaceNebulae)
            {
                throw new IncorrectObstacleForThisEnvironmentException();
            }
        }
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

            obstacle.Damage(ship, ship.Equipment);
        }

        return true;
    }

    public bool IsCanEnterTheEnvironment(ISpaceship ship)
    {
        ship.JumpEngineWork();
        if (ship.JumpEngine is not JumpEngineSlot && (Length <= ship.Range))
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