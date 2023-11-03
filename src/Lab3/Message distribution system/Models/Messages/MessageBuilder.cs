using Itmo.ObjectOrientedProgramming.Lab2.MyException;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Renderable;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

public abstract class MessageBuilder : IMessageBuilder
{
    private IRenderable? _headline;
    private IRenderable? _body;
    private LevelsOfImportance? _importanceLevel;

    public Message Build()
    {
        return new Message(
            _headline,
            _body ?? throw new ThePassedArgumentIsNullException(),
            _importanceLevel ?? throw new ThePassedArgumentIsNullException());
    }

    public MessageBuilder WithHeadline(IRenderable headline)
    {
        _headline = headline;

        return this;
    }

    public MessageBuilder WithBody(IRenderable body)
    {
        _body = body;

        return this;
    }

    public MessageBuilder WithLevelsOfImportance(LevelsOfImportance levelsOfImportance)
    {
        _importanceLevel = levelsOfImportance;

        return this;
    }

    public abstract Message Create(IRenderable? headline, IRenderable body, LevelsOfImportance levelsOfImportance);
}