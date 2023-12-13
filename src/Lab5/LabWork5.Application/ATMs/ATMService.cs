using LabWork5.Application.Abstractions;
using LabWork5.Application.Contracts.ATMs;
using LabWork5.Application.Models.ATMs;

namespace LabWork5.Application.ATMs;

public class ATMService : IATMService
{
    private readonly IATMRepository _repository;

    public ATMService(IATMRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<ATM> GetAllATMs()
    {
        return _repository.GetAllATMs();
    }
}