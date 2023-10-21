namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Factory;

public interface IPartFactory<T, TG>
{
    T CreatePart(TG characteristics);
}