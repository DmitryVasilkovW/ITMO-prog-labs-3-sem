using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class HighDensitySpaceNebulae : Entities.Environment
{
    private Nebulae _nebulae;
    private Spaceship.Entities.Spaceship _ship;
    private int _length;

    public HighDensitySpaceNebulae(Nebulae firstObstacles, Spaceship.Entities.Spaceship ship, int length)
        : base(firstObstacles, ship, length)
    {
         _nebulae = firstObstacles;
         _ship = ship;
         _length = length;
    }

    public new int Length
    {
        get { return _length; }
    }

    public override bool IsCanEnterTheEnvironment()
    {
        if (!_ship.IsjumpEngineInstalled())
        {
            return true;
        }

        return false;
    }

    public void NebulaDamage()
    {
        _ship.Deflector.AsteroidDamage();
    }
}