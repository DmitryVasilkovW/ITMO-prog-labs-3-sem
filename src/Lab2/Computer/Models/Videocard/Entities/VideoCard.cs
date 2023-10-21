using System;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Videocard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Videocard.Entities;

public class VideoCard : IVideoCard, IPart, ICloneable
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
    public object Clone()
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
        var clone = (VideoCard)Clone();

        clone.Name = newName;

        return clone;
    }

    public VideoCard SetVideoCardHeight(int newVideoCardHeight)
    {
        var clone = (VideoCard)Clone();

        clone.VideoCardHeight = newVideoCardHeight;

        return clone;
    }

    public VideoCard SetVideoCardWidth(int newVideoCardWidth)
    {
        var clone = (VideoCard)Clone();

        clone.VideoCardWidth = newVideoCardWidth;

        return clone;
    }

    public VideoCard SetAmountOfVideoMemory(int newAmountOfVideoMemory)
    {
        var clone = (VideoCard)Clone();

        clone.AmountOfVideoMemory = newAmountOfVideoMemory;

        return clone;
    }

    public VideoCard SetPCIEVersion(int newPCIEVersion)
    {
        var clone = (VideoCard)Clone();

        clone.PCIEVersion = newPCIEVersion;

        return clone;
    }

    public VideoCard SetChipFrequency(int newChipFrequency)
    {
        var clone = (VideoCard)Clone();

        clone.ChipFrequency = newChipFrequency;

        return clone;
    }

    public VideoCard SetPowerConsumption(int newPowerConsumption)
    {
        var clone = (VideoCard)Clone();

        clone.PowerConsumption = newPowerConsumption;

        return clone;
    }
}