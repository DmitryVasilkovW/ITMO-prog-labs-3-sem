using System;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class SecondClassDeflector : Deflectors
{
    private int _deflectorconditionlevel;
    private bool _isaPhotonDeflectorInstalled;
    private bool _isDeflectorWorking;
    private IPhotonicDeflectors _photonicDeflector;

    public SecondClassDeflector(IPhotonicDeflectors photonicDeflector)
        : base(photonicDeflector)
    {
        _photonicDeflector = photonicDeflector;
        _deflectorconditionlevel = 7340;
        _isaPhotonDeflectorInstalled = false;
        _isDeflectorWorking = true;
    }

    public new bool IsaPhotonDeflectorInstalled
    {
        get { return _isaPhotonDeflectorInstalled; }
    }

    public new bool IsDeflectorWorking()
    {
        if (_deflectorconditionlevel < 0)
        {
            _isDeflectorWorking = false;
        }

        return _isDeflectorWorking;
    }

    public override void AsteroidDamage()
    {
        _deflectorconditionlevel -= 734;
        IsDeflectorWorking();
    }

    public override void MeteoriteDamage()
    {
        _deflectorconditionlevel -= 2447;
        IsDeflectorWorking();
    }

    public override void SpaceWhaleDamage()
    {
         _deflectorconditionlevel -= 8000;
         IsDeflectorWorking();
    }

    public override void SavingStatusOfTheDeflector(string damagetype)
    {
        if (damagetype.Equals("SpaceWhale", StringComparison.Ordinal))
        {
            _deflectorconditionlevel += 8000;
        }
        else if (damagetype.Equals("Meteorit", StringComparison.Ordinal))
        {
            _deflectorconditionlevel += 2447;
        }
        else
        {
            _deflectorconditionlevel += 734;
        }
    }

    public new void AntimatterFlashesDamage()
    {
        if (IsaPhotonDeflectorInstalled)
        {
            _photonicDeflector.IsPhotonicDeflectorBroken();
        }
    }

    protected new void PhotonDeflectorInstallation(IPhotonicDeflectors photonicDeflector)
    {
        _photonicDeflector = photonicDeflector;
        _isaPhotonDeflectorInstalled = true;
    }
}