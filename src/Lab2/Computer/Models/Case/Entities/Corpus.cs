using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Corpus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Prototype;
using Itmo.ObjectOrientedProgramming.Lab2.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Corpus.Entities;

public class Corpus : ICorpus, IPart, IPrototype<Corpus>
{
    public Corpus(
        string? name,
        int maximumLengthOfTheVideoCard,
        int maximumWidthOfTheVideoCard,
        int supportedMotherboardFormFactors,
        int dimensions,
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
    public int Dimensions { get; private set; }
    public int MaximumCPUCoolerHeight { get; private set; }

    public Corpus Clone()
    {
        if (Name is not null)
        {
            return new Corpus(
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
        Corpus clone = Clone();

        clone.Name = newName;

        return clone;
    }

    public Corpus SetMaximumCPUCoolerHeight(int newMaximumCPUCoolerHeight)
    {
        Corpus clone = Clone();

        clone.MaximumCPUCoolerHeight = newMaximumCPUCoolerHeight;

        return clone;
    }

    public Corpus SetMaximumLengthOfTheVideoCard(int newMaximumLengthOfTheVideoCard)
    {
        Corpus clone = Clone();

        clone.MaximumLengthOfTheVideoCard = newMaximumLengthOfTheVideoCard;

        return clone;
    }

    public Corpus SetMaximumWidthOfTheVideoCard(int newMaximumWidthOfTheVideoCard)
    {
        Corpus clone = Clone();

        clone.MaximumWidthOfTheVideoCard = newMaximumWidthOfTheVideoCard;

        return clone;
    }

    public Corpus SetSupportedMotherboardFormFactors(int newSupportedMotherboardFormFactors)
    {
        Corpus clone = Clone();

        clone.SupportedMotherboardFormFactors = newSupportedMotherboardFormFactors;

        return clone;
    }

    public Corpus SetDimensions(int newDimensions)
    {
        Corpus clone = Clone();

        clone.Dimensions = newDimensions;

        return clone;
    }
}