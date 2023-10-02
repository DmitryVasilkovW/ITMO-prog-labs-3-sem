namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class StandardPhotonicDeflectors : Entities.IPhotonicDeflectors
{
    private int _antimatterFlareResidueBeforeDamage;

    protected StandardPhotonicDeflectors()
    {
        _antimatterFlareResidueBeforeDamage = 3;
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