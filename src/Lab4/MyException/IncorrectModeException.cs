using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.MyException;

public class IncorrectModeException : Exception
{
    public IncorrectModeException(string message)
        : base(message)
    {
    }

    public IncorrectModeException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public IncorrectModeException()
        : base("IncorrectMode")
    {
    }
}