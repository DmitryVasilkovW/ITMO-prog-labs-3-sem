using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class NitrinoParticleNebulae : IEnvironment
{
    private IList<IList<IObstacle>> _obstracles;
    private ISpaceship _ship;

    public NitrinoParticleNebulae(int length, IList<IList<IObstacle>> obstracles,  ISpaceship ship)
    {
        _ship = ship;
        _obstracles = obstracles;
        Length = length;

        foreach (IList<IObstacle> listofobstracles in obstracles)
        {
            foreach (IObstacle obstacle in listofobstracles)
            {
                if (obstacle is not INitrinoParticleNebulae)
                {
                    throw new IncorrectObstacleForThisEnvironmentException();
                }
            }
        }
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
        _ship.EngineWork();
        if (_ship.Engine is IEngine && _ship.Engine is IExponentialAcceleration && (Length <= _ship.Speed))
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