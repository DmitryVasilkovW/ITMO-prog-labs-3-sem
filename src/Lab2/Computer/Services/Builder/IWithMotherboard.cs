using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Motherboard.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services;

public interface IWithMotherboard
{
    IWithCPU WithMotherboard(Motherboard motherboard);
}