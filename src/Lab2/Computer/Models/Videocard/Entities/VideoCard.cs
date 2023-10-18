using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Videocard.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Videocard.Entities;

public class VideoCard : IVideoCard, IPart
{
    public VideoCard(
        int videoCardHeight,
        int videoCardWidth,
        int amountOfVideoMemory,
        int pcieVersion,
        int chipFrequency,
        int powerConsumption,
        string? name)
    {
        VideoCardHeight = videoCardHeight;
        VideoCardWidth = videoCardWidth;
        AmountOfVideoMemory = amountOfVideoMemory;
        PCIEVersion = pcieVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
        Name = name;
    }

    public int VideoCardHeight { get; init; }
    public int VideoCardWidth { get; init; }
    public int AmountOfVideoMemory { get; init; }
    public int PCIEVersion { get; init; }
    public int ChipFrequency { get; init; }
    public int PowerConsumption { get; init; }
    public string? Name { get; init; }
}