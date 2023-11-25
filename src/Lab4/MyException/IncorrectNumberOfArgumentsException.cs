using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.MyException;

public class IncorrectNumberOfArgumentsException : Exception
{
    public IncorrectNumberOfArgumentsException(string message)
        : base(message)
    {
    }

    public IncorrectNumberOfArgumentsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public IncorrectNumberOfArgumentsException()
        : base("Incorrect number of arguments")
    {
    }
}