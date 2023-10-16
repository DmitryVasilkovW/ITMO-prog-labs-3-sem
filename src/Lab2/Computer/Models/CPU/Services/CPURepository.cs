using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Services;

public class CPURepository : ICPURepository
{
    private IList<ICPU> _listOfCPU = new List<ICPU>();

    public void Addcpu(ICPU cpu, string name)
    {
        foreach (ICPU availablecpu in _listOfCPU)
        {
            if (availablecpu.Name is not null && availablecpu.Name.Equals(name, StringComparison.Ordinal))
            {
                throw new AggregateException();
            }
        }

        _listOfCPU.Add(cpu);
    }

    public ICPU FindByName(string name)
    {
        foreach (ICPU cpu in _listOfCPU)
        {
            if (cpu.Name is not null && cpu.Name.Equals(name, StringComparison.Ordinal))
            {
                return cpu;
            }
        }

        throw new AggregateException();
    }
}