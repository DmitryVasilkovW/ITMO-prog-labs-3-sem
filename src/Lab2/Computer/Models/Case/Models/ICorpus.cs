namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Case.Models;

public interface ICorpus
{
    int MaximumLengthOfTheVideoCard { get; init; }
    int MaximumWidthOfTheVideoCard { get; init; }
    int SupportedMotherboardFormFactors { get; init; }
    int Dimensions { get; init; }
}