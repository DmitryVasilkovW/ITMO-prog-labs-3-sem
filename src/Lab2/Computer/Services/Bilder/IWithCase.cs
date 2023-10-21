using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Corpus.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services;

public interface IWithCase
{
    IWithMotherboard WithCase(Corpus corpus);
}