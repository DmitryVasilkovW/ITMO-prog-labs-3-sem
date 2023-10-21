using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Repository;

public interface IRepository
{
    void AddNewPart(int id, IPartCharacteristics newtable);

    IPart GetPart(string name);
}