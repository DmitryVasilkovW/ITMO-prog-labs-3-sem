using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class JumpEngineAlpha : IJumpEngine
{
    private int _weightDimensionsOfTheShip;
    private string _motorOperationType;

    public JumpEngineAlpha(int weightDimensionsOfTheShip)
    {
        _motorOperationType = "Lineal";
        _weightDimensionsOfTheShip = weightDimensionsOfTheShip;
    }

    public string MotorOperationType
    {
        get { return _motorOperationType; }
    }

    public bool ISSlot()
    {
        return false;
    }

    public int Range(int range)
    {
        return range += (range * 2) / _weightDimensionsOfTheShip;
    }

    public int FuelConsumption(int gravitonmatter)
    {
        return gravitonmatter -= gravitonmatter / (2 * _weightDimensionsOfTheShip);
    }
}