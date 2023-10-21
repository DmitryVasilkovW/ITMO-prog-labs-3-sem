using System;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Corpus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Corpus.Entities;

public class Corpus : ICorpus, IPart, ICloneable
{
    public Corpus(
        string? name,
        int maximumLengthOfTheVideoCard,
        int maximumWidthOfTheVideoCard,
        int supportedMotherboardFormFactors,
        Dimensions dimensions,
        int maximumCPUCoolerHeigh)
    {
        Name = name;
        MaximumLengthOfTheVideoCard = maximumLengthOfTheVideoCard;
        MaximumWidthOfTheVideoCard = maximumWidthOfTheVideoCard;
        SupportedMotherboardFormFactors = supportedMotherboardFormFactors;
        Dimensions = dimensions;
        MaximumCPUCoolerHeight = maximumCPUCoolerHeigh;
    }

    public string? Name { get; private set; }
    public int MaximumLengthOfTheVideoCard { get; private set; }
    public int MaximumWidthOfTheVideoCard { get; private set; }
    public int SupportedMotherboardFormFactors { get; private set; }
    public Dimensions Dimensions { get; private set; }
    public int MaximumCPUCoolerHeight { get; private set; }

    public object Clone()
    {
        if (Name is not null)
        {
            return (Corpus)new Corpus(
                (string)Name.Clone(),
                MaximumLengthOfTheVideoCard,
                MaximumWidthOfTheVideoCard,
                SupportedMotherboardFormFactors,
                Dimensions,
                MaximumCPUCoolerHeight);
        }

        throw new ThePassedArgumentIsNullException();
    }

    public Corpus SetName(string? newName)
    {
        var clone = (Corpus)Clone();

        clone.Name = newName;

        return clone;
    }

    public Corpus SetMaximumCPUCoolerHeight(int newMaximumCPUCoolerHeight)
    {
        var clone = (Corpus)Clone();

        clone.MaximumCPUCoolerHeight = newMaximumCPUCoolerHeight;

        return clone;
    }

    public Corpus SetMaximumLengthOfTheVideoCard(int newMaximumLengthOfTheVideoCard)
    {
        var clone = (Corpus)Clone();

        clone.MaximumLengthOfTheVideoCard = newMaximumLengthOfTheVideoCard;

        return clone;
    }

    public Corpus SetMaximumWidthOfTheVideoCard(int newMaximumWidthOfTheVideoCard)
    {
        var clone = (Corpus)Clone();

        clone.MaximumWidthOfTheVideoCard = newMaximumWidthOfTheVideoCard;

        return clone;
    }

    public Corpus SetSupportedMotherboardFormFactors(int newSupportedMotherboardFormFactors)
    {
        var clone = (Corpus)Clone();

        clone.SupportedMotherboardFormFactors = newSupportedMotherboardFormFactors;

        return clone;
    }

    public Corpus SetDimensions(Dimensions newDimensions)
    {
        var clone = (Corpus)Clone();

        clone.Dimensions = newDimensions;

        return clone;
    }
}