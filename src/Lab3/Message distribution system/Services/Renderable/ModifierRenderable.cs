namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Renderable;

public class ModifierRenderable : IRenderable
{
    private readonly IRenderable _renderable;
    private readonly IRenderableModifier _modifier;

    public ModifierRenderable(
        IRenderable renderable,
        IRenderableModifier modifier)
    {
        _renderable = renderable;
        _modifier = modifier;
    }

    public string? Render()
    {
        return _modifier.Modify(_renderable.Render());
    }
}