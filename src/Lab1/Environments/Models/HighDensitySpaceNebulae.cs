using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class HighDensitySpaceNebulae : Entities.Environment
{
    private Nebulae _nebulae;
    private Spaceship.Entities.Spaceship _ship;
    private int _subspaceChannelLength;

    public HighDensitySpaceNebulae(Nebulae firstObstacles, Spaceship.Entities.Spaceship ship)
        : base(firstObstacles, ship)
    {
         _nebulae = firstObstacles;
         _ship = ship;
         RequiredEngine = "JumpEngine";
         _subspaceChannelLength = 100;
    }

    public int SubspaceChannelLength
    {
        get { return _subspaceChannelLength; }
    }

    public void NebulaDamage()
    {
        _ship.Deflector.AsteroidDamage();
    }
}