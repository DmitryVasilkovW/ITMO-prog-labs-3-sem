using LabWork5.Application.Models.Users;

namespace LabWork5.Application.Contracts.Users;

public interface ICurrentUserService
{
    User? User { get; }
}