using LabWork5.Application.Models.Users;

namespace LabWork5.Application.Abstractions;

public interface IUserRepository
{
    User? FindUserByUsername(string username);
}