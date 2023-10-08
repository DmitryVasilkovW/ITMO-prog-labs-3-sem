namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;

public interface IEnvironment
{
    bool IsTheShipWasAbleToRemainInService();

    bool IsCanEnterTheEnvironment();

    bool IsShipAlive();

    bool IsObstaclesKillStaff();
}