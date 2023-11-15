using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.MyException;

public class IncorrectModeTypeException : Exception
{
    public IncorrectModeTypeException(string message)
        : base(message)
    {
    }

    public IncorrectModeTypeException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public IncorrectModeTypeException()
        : base("IncorrectModeType")
    {
    }
}