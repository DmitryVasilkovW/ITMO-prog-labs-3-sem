using LabWork5.Application.Models.ATMs;

namespace LabWork5.Application.Contracts.ATMs;

public interface IATMService
{
    IEnumerable<ATM> GetAllATMs();
}