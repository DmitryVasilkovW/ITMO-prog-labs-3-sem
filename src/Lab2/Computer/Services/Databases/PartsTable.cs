namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

public class PartsTable
{
    public PartsTable(int id, IPartCharacteristics partCharacteristics)
    {
        ID = id;
        PartCharacteristics = partCharacteristics;
    }

    public int ID { get; }
    public IPartCharacteristics PartCharacteristics { get; }
}