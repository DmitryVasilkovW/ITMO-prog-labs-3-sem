namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Services;

public interface ICPURepository
{
    ICPU FindByName(string name);
    public void Addcpu(ICPU cpu, string name);
}