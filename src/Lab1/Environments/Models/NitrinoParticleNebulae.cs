namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class NitrinoParticleNebulae : Entities.Environment
{
    private Services.Nebulae _nebulae;
    private Services.SpaceWhale _spaceWhale;
    private Spaceship.Entities.Spaceship _ship;

    public NitrinoParticleNebulae(Services.Nebulae obstacles, Services.SpaceWhale spaceWhale, Spaceship.Entities.Spaceship ship)
        : base(obstacles, spaceWhale, ship)
    {
        _spaceWhale = spaceWhale;
        _nebulae = obstacles;
        _ship = ship;
        RequiredEngine = "PulseEngine";
    }

    public void NebulaeDamage()
    {
        if (_ship.EngineType == "PulseEngine")
        _nebulae.Damage(_ship);
    }

    public void SpaceWhaleDamage()
    {
        _spaceWhale.Damage(_ship);
    }
}