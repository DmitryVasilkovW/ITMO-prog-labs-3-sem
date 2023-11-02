using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Extensions;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Renderable;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

public class StyledMessageBuilder : MessageBuilder
{
    private readonly ConsoleColor _titleColor;

    public StyledMessageBuilder(ConsoleColor titleColor)
    {
        _titleColor = titleColor;
    }

    public override Message Create(IRenderable? headline, IRenderable body, LevelsOfImportance levelsOfImportance)
    {
        return new Message(
            headline,
            body.WithModifier(
                    new ColorModifier(_titleColor)),
            levelsOfImportance);
    }
}