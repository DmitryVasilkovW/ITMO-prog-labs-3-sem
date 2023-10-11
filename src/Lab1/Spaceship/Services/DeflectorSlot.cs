using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class DeflectorSlot : Deflectors
{
    public DeflectorSlot()
    {
        IsaPhotonDeflectorInstalled = false;
    }

    public override bool IsaPhotonDeflectorInstalled { get; }

    public override bool IsPhotonDeflectorWorking()
    {
        return false;
    }

    public override bool IsWorking()
    {
        return false;
    }

    public override void AsteroidDamage()
    {
    }

    public override void MeteoriteDamage()
    {
    }

    public override void SpaceWhaleDamage()
    {
    }

    public override void SavingStatusOfTheDeflector(AdditionalSafetyDevices device)
    {
    }
}