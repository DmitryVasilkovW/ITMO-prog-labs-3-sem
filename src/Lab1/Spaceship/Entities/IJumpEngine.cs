namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

public interface IJumpEngine
{
    int Range(int range);
    int FuelConsumption(int gravitonmatter);

    bool ISSlot();
}