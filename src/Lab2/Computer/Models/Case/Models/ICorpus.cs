namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Corpus.Models;

public interface ICorpus
{
    int MaximumLengthOfTheVideoCard { get; }
    int MaximumWidthOfTheVideoCard { get; }
    int SupportedMotherboardFormFactors { get; }
    Dimensions Dimensions { get; }
    int MaximumCPUCoolerHeight { get; }
}