using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Extensions;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

public class StyledParagraphBuilder : MessageBuilder
{
    private readonly ConsoleColor _titleColor;

    public StyledParagraphBuilder(ConsoleColor titleColor)
    {
        _titleColor = titleColor;
    }

    public override Message Create(Message message)
    {
        return new Message(
            message.Headline,
            message.Body.WithModifier(
                    new ColorModifier(_titleColor)),
            message.ImportanceLevels);
    }
}