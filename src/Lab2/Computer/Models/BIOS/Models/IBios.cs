using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.BIOS.Models;

public interface IBios
{
    int Version { get; }
    IList<ICPU>? ListOfSupportedCPUs { get; }
}