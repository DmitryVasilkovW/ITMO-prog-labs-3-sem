using LabWork5.Application.Contracts.Users;
using LabWork5.Application.Models.Users;

namespace LabWork5.Application.Users;

public class CurrentUserManager : ICurrentUserService
{
    public User? User { get; set; }
}