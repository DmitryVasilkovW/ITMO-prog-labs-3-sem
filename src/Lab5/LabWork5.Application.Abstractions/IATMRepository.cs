using LabWork5.Application.Models.ATMs;

namespace LabWork5.Application.Abstractions;

public interface IATMRepository
{
    IEnumerable<ATM> GetAllATMs();
}