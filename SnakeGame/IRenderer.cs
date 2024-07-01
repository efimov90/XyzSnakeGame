using System.Numerics;

namespace SnakeGame;
public interface IRenderer
{
    void DrawHeadAt(Vector2 head);
    void EraseAt(Vector2 coordinate);
    void RenderCoordinates(Vector2 coordinate);
}