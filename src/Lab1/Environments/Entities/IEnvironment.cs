namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;

public interface IEnvironment
{
    string SecondTypeObstracleType { get; }

    int CountOfFirstTypeObstracles { get; }

    int CountOfSecondTypeObstracles { get; }

    int Length { get; }

    bool IsTheShipWasAbleToRemainInService();

    bool IsCanEnterTheEnvironment();

    bool IsShipAlive();

    bool IsObstaclesKillStaff();
}