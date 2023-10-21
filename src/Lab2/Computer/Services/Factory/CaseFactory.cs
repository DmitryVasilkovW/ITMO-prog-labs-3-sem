using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Corpus.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Factory;

public class CaseFactory : IPartFactory<Corpus, TableOfCaseCharacteristics>
{
    public Corpus CreatePart(TableOfCaseCharacteristics characteristics)
    {
        return new Corpus(
            characteristics.Name,
            characteristics.MaximumLengthOfTheVideoCard,
            characteristics.MaximumWidthOfTheVideoCard,
            characteristics.SupportedMotherboardFormFactors,
            characteristics.Dimensions,
            characteristics.MaximumCPUCoolerHeight);
    }
}