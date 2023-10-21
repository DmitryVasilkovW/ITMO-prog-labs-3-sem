using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Videocard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Prototype;
using Itmo.ObjectOrientedProgramming.Lab2.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Videocard.Entities;

public class VideoCard : IVideoCard, IPart, IPrototype<VideoCard>
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

    public int VideoCardHeight { get; private set; }
    public int VideoCardWidth { get; private set; }
    public int AmountOfVideoMemory { get; private set; }
    public int PCIEVersion { get; private set; }
    public int ChipFrequency { get; private set; }
    public int PowerConsumption { get; private set; }
    public string? Name { get; private set; }
    public VideoCard Clone()
    {
        if (Name is not null)
        {
            return new VideoCard(
                VideoCardHeight,
                VideoCardWidth,
                AmountOfVideoMemory,
                PCIEVersion,
                ChipFrequency,
                PowerConsumption,
                (string)Name.Clone());
        }

        throw new ThePassedArgumentIsNullException();
    }

    public VideoCard SetName(string? newName)
    {
        VideoCard clone = Clone();

        clone.Name = newName;

        return clone;
    }

    public VideoCard SetVideoCardHeight(int newVideoCardHeight)
    {
        VideoCard clone = Clone();

        clone.VideoCardHeight = newVideoCardHeight;

        return clone;
    }

    public VideoCard SetVideoCardWidth(int newVideoCardWidth)
    {
        VideoCard clone = Clone();

        clone.VideoCardWidth = newVideoCardWidth;

        return clone;
    }

    public VideoCard SetAmountOfVideoMemory(int newAmountOfVideoMemory)
    {
        VideoCard clone = Clone();

        clone.AmountOfVideoMemory = newAmountOfVideoMemory;

        return clone;
    }

    public VideoCard SetPCIEVersion(int newPCIEVersion)
    {
        VideoCard clone = Clone();

        clone.PCIEVersion = newPCIEVersion;

        return clone;
    }

    public VideoCard SetChipFrequency(int newChipFrequency)
    {
        VideoCard clone = Clone();

        clone.ChipFrequency = newChipFrequency;

        return clone;
    }

    public VideoCard SetPowerConsumption(int newPowerConsumption)
    {
        VideoCard clone = Clone();

        clone.PowerConsumption = newPowerConsumption;

        return clone;
    }
}