using LabWork5.Application.Models.Users;

namespace Workshop5.Application.Abstractions;

public interface IUserRepository
{
    User? FindUserByUsername(string username);
}