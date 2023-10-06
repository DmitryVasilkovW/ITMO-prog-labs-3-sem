namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class ValuesForTheEnvironment
{
    private string _environment;
    private Spaceship.Entities.ISpaceship _ship;
    private int _length;
    private int _countOfFirstTypeObstracles;
    private int _countOfSecondTypeObstracles;

    public ValuesForTheEnvironment(string environment, Spaceship.Entities.ISpaceship ship, int length, int countOfFirstTypeObstracles, int countOfSecondTypeObstracles)
    {
        _environment = environment;
        _length = length;
        _ship = ship;
        _countOfFirstTypeObstracles = countOfFirstTypeObstracles;
        _countOfSecondTypeObstracles = countOfSecondTypeObstracles;
    }

    public string Environment
    {
        get { return _environment; }
    }

    public Spaceship.Entities.ISpaceship Ship
    {
        get { return _ship; }
    }

    public int Length
    {
        get { return _length; }
    }

    public int CountOfFirstTypeObstracles
    {
        get { return _countOfFirstTypeObstracles; }
    }

    public int CountOfSecondTypeObstracles
    {
        get { return _countOfSecondTypeObstracles; }
    }
}