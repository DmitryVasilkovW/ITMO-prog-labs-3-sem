using System.Text;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Renderable;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

public class Message : IMessage
{
    public Message(IRenderable? headline, IRenderable body, LevelsOfImportance importanceLevel)
    {
        Headline = headline;
        Body = body;
        ImportanceLevels = importanceLevel;
    }

    public IRenderable Body { get; }
    public IRenderable? Headline { get; }
    public LevelsOfImportance ImportanceLevels { get; }
    public string? Render()
    {
        var builder = new StringBuilder();

        if (Headline is not null)
            builder.Append(Headline.Render());

        builder.Append(Body.Render());

        return builder.ToString();
    }

    public bool Equals(Message obj)
    {
        if (Headline is not null
            && obj.Headline is not null
            && Headline.Equals(obj.Headline)
            && Body.Equals(obj.Body)
            && ImportanceLevels
            == obj.ImportanceLevels)
        {
            return true;
        }

        return false;
    }
}