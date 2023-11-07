using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Renderable;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Extensions;

public static class RenderableExtensions
{
    public static IRenderable WithModifier(
        this IRenderable renderable,
        IRenderableModifier modifier)
    {
        return new ModifierRenderable(renderable, modifier);
    }
}