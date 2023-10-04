namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class ValuesForTheEnvironment
{
    private string _environment;
    private Spaceship.Entities.Spaceship _ship;
    private int _length;
    private int _countOfObstracles;

    public ValuesForTheEnvironment(string environment, Spaceship.Entities.Spaceship ship, int length, int countOfObstracles)
    {
        _environment = environment;
        _length = length;
        _ship = ship;
        _countOfObstracles = countOfObstracles;
    }

    public string Environment
    {
        get { return _environment; }
    }

    public Spaceship.Entities.Spaceship Ship
    {
        get { return _ship; }
    }

    public int Length
    {
        get { return _length; }
    }

    public int CountOfObstracles
    {
        get { return _countOfObstracles; }
    }
}