namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Videocard.Models;

public interface IVideoCard
{
    int VideoCardHeight { get; init; }
    int VideoCardWidth { get; init; }
    int AmountOfVideoMemory { get; init; }
    int PCIEVersion { get; init; }
    int ChipFrequency { get; init; }
    int PowerConsumption { get; init; }
}