using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Renderable;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

public class BaseMessageBuilder : MessageBuilder
{
    public override Message Create(
        IRenderable? headline,
        IRenderable body,
        LevelsOfImportance levelsOfImportance)
    {
        return new Message(headline, body, levelsOfImportance);
    }
}