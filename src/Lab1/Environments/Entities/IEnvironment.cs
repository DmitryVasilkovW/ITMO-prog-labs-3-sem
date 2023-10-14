using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;

public interface IEnvironment
{
    bool IsTheShipWasAbleToRemainInService(ISpaceship ship);

    bool IsCanEnterTheEnvironment(ISpaceship ship);

    bool IsObstaclesKillStaff();
}