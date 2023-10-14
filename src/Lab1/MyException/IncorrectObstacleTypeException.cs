using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.MyException;

public class IncorrectObstacleTypeException : Exception
{
    public IncorrectObstacleTypeException()
        : base("an incorrect obstruction was submitted")
    {
    }

    public IncorrectObstacleTypeException(string message)
        : base(message)
    {
    }

    public IncorrectObstacleTypeException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}