using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.MyException;

public class IncorrectOperationException : Exception
{
    public IncorrectOperationException(string message)
        : base(message)
    {
    }

    public IncorrectOperationException()
        : base("IncorrectOperation")
    {
    }

    public IncorrectOperationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}