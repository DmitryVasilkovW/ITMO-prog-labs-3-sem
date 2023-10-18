using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Case.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

public class TableOfCaseCharacteristics : ICorpus, IPartCharacteristics
{
    public string? Name { get; init; }
    public int MaximumLengthOfTheVideoCard { get; init; }
    public int MaximumWidthOfTheVideoCard { get; init; }
    public int SupportedMotherboardFormFactors { get; init; }
    public int Dimensions { get; init; }
}