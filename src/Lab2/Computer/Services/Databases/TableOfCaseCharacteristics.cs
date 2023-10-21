using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Corpus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

public class TableOfCaseCharacteristics : ICorpus, IPartCharacteristics
{
    public TableOfCaseCharacteristics(
        string name,
        int maximumLengthOfTheVideoCard,
        int maximumWidthOfTheVideoCard,
        int supportedMotherboardFormFactors,
        Dimensions dimensions,
        int maximumCpuCoolerHeight)
    {
        Name = name;
        MaximumLengthOfTheVideoCard = maximumLengthOfTheVideoCard;
        MaximumWidthOfTheVideoCard = maximumWidthOfTheVideoCard;
        SupportedMotherboardFormFactors = supportedMotherboardFormFactors;
        Dimensions = dimensions;
        MaximumCPUCoolerHeight = maximumCpuCoolerHeight;
    }

    public string? Name { get; }
    public int MaximumLengthOfTheVideoCard { get; }
    public int MaximumWidthOfTheVideoCard { get; }
    public int SupportedMotherboardFormFactors { get; }
    public Dimensions Dimensions { get; }
    public int MaximumCPUCoolerHeight { get; }
}