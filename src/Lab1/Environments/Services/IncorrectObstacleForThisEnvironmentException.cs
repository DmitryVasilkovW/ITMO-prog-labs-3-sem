using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class IncorrectObstacleForThisEnvironmentException : Exception
{
    public IncorrectObstacleForThisEnvironmentException()
        : base("the obstacle can't be contained in this environment")
    {
    }

    public IncorrectObstacleForThisEnvironmentException(string message)
        : base(message)
    {
    }

    public IncorrectObstacleForThisEnvironmentException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}