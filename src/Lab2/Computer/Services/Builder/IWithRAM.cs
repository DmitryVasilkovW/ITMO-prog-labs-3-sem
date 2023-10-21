using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.RAM.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services;

public interface IWithRAM
{
    IWithHardDrive WithRAM(IList<Ram> ram);
}