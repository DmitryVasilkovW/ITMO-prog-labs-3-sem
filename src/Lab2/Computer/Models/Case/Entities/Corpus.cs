using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Case.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Case.Entities;

public class Corpus : ICorpus, IPart
{
    public Corpus(
        string? name,
        int maximumLengthOfTheVideoCard,
        int maximumWidthOfTheVideoCard,
        int supportedMotherboardFormFactors,
        int dimensions)
    {
        Name = name;
        MaximumLengthOfTheVideoCard = maximumLengthOfTheVideoCard;
        MaximumWidthOfTheVideoCard = maximumWidthOfTheVideoCard;
        SupportedMotherboardFormFactors = supportedMotherboardFormFactors;
        Dimensions = dimensions;
    }

    public string? Name { get; init; }
    public int MaximumLengthOfTheVideoCard { get; init; }
    public int MaximumWidthOfTheVideoCard { get; init; }
    public int SupportedMotherboardFormFactors { get; init; }
    public int Dimensions { get; init; }
}