using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.MyException;

public class ThePassedArgumentIsNullException : Exception
{
    public ThePassedArgumentIsNullException()
        : base("The passed argument is null")
    {
    }

    public ThePassedArgumentIsNullException(string message)
        : base(message)
    {
    }

    public ThePassedArgumentIsNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}