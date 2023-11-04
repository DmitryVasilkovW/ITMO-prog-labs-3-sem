using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.MyException;

public class IncorrectNumberOfArgumentsException : Exception
{
    public IncorrectNumberOfArgumentsException()
        : base("an incorrect number of arguments has been passed to the tester")
    {
    }

    public IncorrectNumberOfArgumentsException(string message)
        : base(message)
    {
    }

    public IncorrectNumberOfArgumentsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}