namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Factory;

public interface ICPUPartFactory<T, TG>
{
    T CreatePart(TG characteristics);
}