namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Videocard.Models;

public interface IVideoCard
{
    int VideoCardHeight { get; }
    int VideoCardWidth { get; }
    int AmountOfVideoMemory { get; }
    int PCIEVersion { get; }
    int ChipFrequency { get; }
    int PowerConsumption { get; }
}