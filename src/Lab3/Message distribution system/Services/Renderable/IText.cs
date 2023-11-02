namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Renderable;

public interface IText<T>
    : IRenderable
    where T : IText<T>
{
    T AddModifier(IRenderableModifier modifier);
}