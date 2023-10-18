using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Case.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Factory;

public class CaseFactory : IPartFactory<Corpus, TableOfCaseCharacteristics>
{
    public Corpus CreatePart(TableOfCaseCharacteristics characteristics)
    {
        string? name = characteristics.Name;
        int maximumLengthOfTheVideoCard = characteristics.MaximumLengthOfTheVideoCard;
        int maximumWidthOfTheVideoCard = characteristics.MaximumWidthOfTheVideoCard;
        int supportedMotherboardFormFactors = characteristics.SupportedMotherboardFormFactors;
        int dimensions = characteristics.Dimensions;

        return new Corpus(
            name,
            maximumLengthOfTheVideoCard,
            maximumWidthOfTheVideoCard,
            supportedMotherboardFormFactors,
            dimensions);
    }
}