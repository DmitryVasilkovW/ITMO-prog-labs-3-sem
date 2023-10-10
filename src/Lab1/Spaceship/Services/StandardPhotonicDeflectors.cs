using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class StandardPhotonicDeflectors : IPhotonicDeflectors
{
    private const int InitialAntimatterFlareResidueBeforeDamage = 3;
    private int _antimatterFlareResidueBeforeDamage;

    public StandardPhotonicDeflectors()
    {
        _antimatterFlareResidueBeforeDamage = InitialAntimatterFlareResidueBeforeDamage;
    }

    public bool IsPhotonicDeflectorBroken()
    {
        _antimatterFlareResidueBeforeDamage--;

        if (_antimatterFlareResidueBeforeDamage <= 0)
        {
            return true;
        }

        return false;
    }
}