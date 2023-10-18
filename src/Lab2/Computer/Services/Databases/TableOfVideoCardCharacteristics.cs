using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Videocard.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

public class TableOfVideoCardCharacteristics : IVideoCard, IPartCharacteristics
{
    public int VideoCardHeight { get; init; }
    public int VideoCardWidth { get; init; }
    public int AmountOfVideoMemory { get; init; }
    public int PCIEVersion { get; init; }
    public int ChipFrequency { get; init; }
    public int PowerConsumption { get; init; }
    public string? Name { get; init; }
}