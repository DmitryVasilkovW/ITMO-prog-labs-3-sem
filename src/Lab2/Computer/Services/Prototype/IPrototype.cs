namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Prototype;

public interface IPrototype<T>
    where T : IPrototype<T>
{
    T Clone();
}