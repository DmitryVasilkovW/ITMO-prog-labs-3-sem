using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class HighDensitySpaceNebulae : Entities.Environment
{
    private Nebulae _nebulae;
    private Spaceship.Entities.Spaceship _ship;
    private int _length;
    private int _countOfObstracles;

    public HighDensitySpaceNebulae(int length, int countOfObstracles, Spaceship.Entities.Spaceship ship)
        : base(length, countOfObstracles, ship)
    {
         _nebulae = new Nebulae();
         _ship = ship;
         _countOfObstracles = countOfObstracles;
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