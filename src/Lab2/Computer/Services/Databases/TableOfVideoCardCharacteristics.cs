using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Videocard.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

public class TableOfVideoCardCharacteristics : IVideoCard, IPartCharacteristics
{
    public TableOfVideoCardCharacteristics(
        int videoCardHeight,
        int videoCardWidth,
        int amountOfVideoMemory,
        int pcieVersion,
        int chipFrequency,
        int powerConsumption,
        string name)
    {
        VideoCardHeight = videoCardHeight;
        VideoCardWidth = videoCardWidth;
        AmountOfVideoMemory = amountOfVideoMemory;
        PCIEVersion = pcieVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
        Name = name;
    }

    public int VideoCardHeight { get; }
    public int VideoCardWidth { get; }
    public int AmountOfVideoMemory { get; }
    public int PCIEVersion { get; }
    public int ChipFrequency { get; }
    public int PowerConsumption { get; }
    public string? Name { get; }
}