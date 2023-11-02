using System;
using System.Collections.Generic;
using System.Linq;

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
            (c, m) => m.Modify(c) ?? throw new InvalidOperationException());
    }

    public Text AddModifier(IRenderableModifier modifier)
    {
        _modifiers.Add(modifier);
        return this;
    }
}