using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Factory;

public class CPUFactory : IPartFactory<Processor, TableOfCPUCharacteristics>
{
    public Processor CreatePart(TableOfCPUCharacteristics characteristics)
    {
        return new Processor(characteristics);
    }
}
