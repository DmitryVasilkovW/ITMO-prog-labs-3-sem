using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Renderable;

public class Text : IText<Text>
{
    private readonly List<IRenderableModifier> _modifiers;

    public Text(string content)
    {
        Content = content;
        _modifiers = new List<IRenderableModifier>();
    }

    public string Content { get; }

    public string Render()
    {
        return _modifiers.Aggregate(
            Content,
            (content, modifire) => modifire.Modify(content) ?? throw new IncorrectOperationException());
    }

    public Text AddModifier(IRenderableModifier modifier)
    {
        _modifiers.Add(modifier);
        return this;
    }
}